USE HiroPhoneDB;
GO

-- =========================================================================
-- MÓDULO 1: SOPORTE TÉCNICO (FormSoporte.cs)
-- =========================================================================

-- 1. Listar órdenes de trabajo con su cliente
IF OBJECT_ID('sp_ListarServiciosTecnicos', 'P') IS NOT NULL
    DROP PROCEDURE sp_ListarServiciosTecnicos;
GO

CREATE PROCEDURE sp_ListarServiciosTecnicos
AS
BEGIN
    SET NOCOUNT ON;
    SELECT TOP 100
        st.id_servicio AS [OT #],
        c.nombre_o_razon_social AS [Cliente],
        'Celular Cliente' AS [Equipo],
        st.descripcion_falla AS [Falla Reportada],
        150.00 AS [Costo],
        st.estado_servicio AS [Estado],
        CONVERT(VARCHAR(10), st.fecha_ingreso, 103) AS [Fecha Ingreso]
    FROM 
        Servicio_Tecnico st
        INNER JOIN Cliente c ON st.id_cliente = c.id_cliente
    ORDER BY 
        st.fecha_ingreso DESC;
END;
GO

-- 2. Buscar cliente existente o crear uno nuevo (Soporte)
IF OBJECT_ID('sp_ObtenerOCrearClienteSoporte', 'P') IS NOT NULL
    DROP PROCEDURE sp_ObtenerOCrearClienteSoporte;
GO

CREATE PROCEDURE sp_ObtenerOCrearClienteSoporte
    @nombre VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @id_cliente INT;
    
    -- Intentar buscar el cliente por nombre
    SELECT @id_cliente = id_cliente 
    FROM Cliente 
    WHERE nombre_o_razon_social = @nombre;
    
    -- Si no existe, crearlo con datos por defecto/aleatorios
    IF @id_cliente IS NULL
    BEGIN
        DECLARE @doc VARCHAR(20) = '10' + CAST(CAST(RAND() * 89999999 + 10000000 AS INT) AS VARCHAR);
        DECLARE @correo VARCHAR(250) = REPLACE(@nombre, ' ', '') + '@gmail.com';
        DECLARE @tel VARCHAR(20) = '9' + CAST(CAST(RAND() * 89999999 + 10000000 AS INT) AS VARCHAR);
        
        INSERT INTO Cliente (numero_documento, nombre_o_razon_social, correo, telefono, id_tipo_cliente)
        VALUES (@doc, @nombre, LOWER(@correo), @tel, 1);
        
        SET @id_cliente = SCOPE_IDENTITY();
    END;
    
    SELECT @id_cliente AS id_cliente;
END;
GO

-- 3. Insertar o actualizar una orden de soporte técnico
IF OBJECT_ID('sp_GuardarServicioTecnico', 'P') IS NOT NULL
    DROP PROCEDURE sp_GuardarServicioTecnico;
GO

CREATE PROCEDURE sp_GuardarServicioTecnico
    @id_servicio INT = 0,
    @descripcion_falla VARCHAR(MAX),
    @estado_servicio VARCHAR(50),
    @id_cliente INT,
    @id_empleado INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    IF @id_servicio > 0
    BEGIN
        -- Operación: Modificación (UPDATE)
        UPDATE Servicio_Tecnico
        SET descripcion_falla = @descripcion_falla,
            estado_servicio = @estado_servicio,
            id_cliente = @id_cliente
        WHERE id_servicio = @id_servicio;
    END
    ELSE
    BEGIN
        -- Operación: Inserción (INSERT)
        IF @id_empleado IS NULL
        BEGIN
            -- Fallback si no hay empleado activo
            SELECT TOP 1 @id_empleado = id_empleado FROM Empleado;
        END;
        
        INSERT INTO Servicio_Tecnico (fecha_ingreso, descripcion_falla, estado_servicio, id_cliente, id_empleado)
        VALUES (GETDATE(), @descripcion_falla, @estado_servicio, @id_cliente, @id_empleado);
    END;
END;
GO

-- 4. Eliminar una orden de soporte técnico
IF OBJECT_ID('sp_EliminarServicioTecnico', 'P') IS NOT NULL
    DROP PROCEDURE sp_EliminarServicioTecnico;
GO

CREATE PROCEDURE sp_EliminarServicioTecnico
    @id_servicio INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Servicio_Tecnico WHERE id_servicio = @id_servicio;
END;
GO


-- =========================================================================
-- MÓDULO 2: TRANSACCIÓN DE VENTAS (FormVentas.cs)
-- =========================================================================

-- 1. Obtener o registrar cliente en venta (Maneja RUC de 11 dígitos o nombres comunes)
IF OBJECT_ID('sp_ObtenerOCrearClienteVenta', 'P') IS NOT NULL
    DROP PROCEDURE sp_ObtenerOCrearClienteVenta;
GO

CREATE PROCEDURE sp_ObtenerOCrearClienteVenta
    @requiereRuc INT,
    @cliente VARCHAR(250)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @id_cliente INT;
    
    IF @requiereRuc = 1
    BEGIN
        -- Cliente con RUC (Persona Jurídica)
        SELECT @id_cliente = id_cliente FROM Cliente WHERE numero_documento = @cliente;
        IF @id_cliente IS NULL
        BEGIN
            INSERT INTO Cliente (numero_documento, nombre_o_razon_social, id_tipo_cliente) 
            VALUES (@cliente, 'Empresa RUC ' + @cliente, 2);
            SET @id_cliente = SCOPE_IDENTITY();
        END;
    END
    ELSE
    BEGIN
        -- Cliente Boleta (Persona Natural)
        SELECT @id_cliente = id_cliente FROM Cliente WHERE nombre_o_razon_social = @cliente;
        IF @id_cliente IS NULL
        BEGIN
            DECLARE @numDoc VARCHAR(20) = 'CLI' + REPLACE(CONVERT(VARCHAR(8), GETDATE(), 108), ':', '') + CAST(CAST(RAND() * 99 AS INT) AS VARCHAR);
            INSERT INTO Cliente (numero_documento, nombre_o_razon_social, id_tipo_cliente) 
            VALUES (@numDoc, @cliente, 1);
            SET @id_cliente = SCOPE_IDENTITY();
        END;
    END;
    
    SELECT @id_cliente AS id_cliente;
END;
GO

-- 2. Obtener el siguiente correlativo diario de venta
IF OBJECT_ID('sp_ObtenerSiguienteCorrelativoVenta', 'P') IS NOT NULL
    DROP PROCEDURE sp_ObtenerSiguienteCorrelativoVenta;
GO

CREATE PROCEDURE sp_ObtenerSiguienteCorrelativoVenta
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(MAX(correlativo_diario), 0) + 1 FROM Venta;
END;
GO

-- 3. Insertar la cabecera de la venta y retornar su ID
IF OBJECT_ID('sp_InsertarCabeceraVenta', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertarCabeceraVenta;
GO

CREATE PROCEDURE sp_InsertarCabeceraVenta
    @serie VARCHAR(10),
    @correlativo INT,
    @subtotal DECIMAL(18,2),
    @igv DECIMAL(18,2),
    @total DECIMAL(18,2),
    @idCliente INT,
    @idEmpleado INT,
    @idMetodo INT,
    @idTipoComprobante INT,
    @montoEfectivo DECIMAL(18,2) = NULL,
    @montoTarjeta DECIMAL(18,2) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Venta (fecha_venta, serie_comprobante, correlativo_diario, subtotal, igv, total_venta, id_cliente, id_empleado, id_metodo_pago, id_tipo_comprobante, id_caja, monto_efectivo, monto_tarjeta)
    VALUES (GETDATE(), @serie, @correlativo, @subtotal, @igv, @total, @idCliente, @idEmpleado, @idMetodo, @idTipoComprobante, 1, @montoEfectivo, @montoTarjeta);
    
    SELECT SCOPE_IDENTITY() AS id_venta;
END;
GO

-- 4. Registrar los detalles de la venta y descontar stock automáticamente
IF OBJECT_ID('sp_InsertarDetalleYActualizarStock', 'P') IS NOT NULL
    DROP PROCEDURE sp_InsertarDetalleYActualizarStock;
GO

CREATE PROCEDURE sp_InsertarDetalleYActualizarStock
    @idVenta INT,
    @nombreProducto VARCHAR(250),
    @cantidad INT,
    @precioUnitario DECIMAL(18,2),
    @subtotal DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @idProducto INT;
    
    -- Buscar el id_producto a través de su nombre
    SELECT TOP 1 @idProducto = id_producto 
    FROM Producto 
    WHERE nombre_producto = @nombreProducto;
    
    -- Insertar el ítem en la tabla de detalles
    INSERT INTO Detalle_Venta (id_venta, id_producto, cantidad, precio_unitario, subtotal)
    VALUES (@idVenta, @idProducto, @cantidad, @precioUnitario, @subtotal);
    
    -- Transacción: Descontar stock actual de almacén principal (id_almacen = 1)
    UPDATE Inventario 
    SET stock_actual = stock_actual - @cantidad 
    WHERE id_producto = @idProducto AND id_almacen = 1;
END;
GO

-- 5. Registrar comisión para el vendedor (Empleado)
IF OBJECT_ID('sp_RegistrarComisionEmpleado', 'P') IS NOT NULL
    DROP PROCEDURE sp_RegistrarComisionEmpleado;
GO

CREATE PROCEDURE sp_RegistrarComisionEmpleado
    @idEmpleado INT,
    @idVenta INT,
    @totalVenta DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @porcentajeComision DECIMAL(5,2) = 3.00; -- Comisión fija del 3%
    DECLARE @montoComision DECIMAL(18,2) = @totalVenta * (@porcentajeComision / 100.00);
    
    INSERT INTO Comision_Empleado (porcentaje, monto_comision, fecha_generacion, estado_pago, id_empleado, id_venta)
    VALUES (@porcentajeComision, @montoComision, CAST(GETDATE() AS DATE), 'Pendiente', @idEmpleado, @idVenta);
END;
GO
