CREATE DATABASE almacen;
USE almacen;

CREATE TABLE partidas(
    id_partida BIGINT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(500)
);


CREATE TABLE partidas(
    id_partida BIGINT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(500)
);

CREATE TABLE insumos(
    id_insumo BIGINT PRIMARY KEY AUTO_INCREMENT,
    clave VARCHAR(20),
    descripcion VARCHAR(70),
    id_partida BIGINT,
    unidad_medida VARCHAR (10),
    FOREIGN KEY(id_partida) REFERENCES partidas(id_partida));

    CREATE TABLE listainsumo(
    id_Listainsumo bigint PRIMARY KEY AUTO_INCREMENT,
    id_insumo BIGINT ,
    proyecto VARCHAR(10),
    cantidad FLOAT,
    status BOOLEAN,
    FOREIGN key (id_insumo) REFERENCES insumos(id_insumo));

CREATE TABLE requisicion_compras(
    id_compra BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_insumo BIGINT ,
    fecha DATETIME,
    cantidad FLOAT,
    comprador VARCHAR(100),
    numero INT,
    solicitante VARCHAR(100), 
    revisor VARCHAR(100),
    autorizante VARCHAR(100),
    observaciones VARCHAR(100),
    centro_costo VARCHAR(20),
    prioridad VARCHAR(20),
    unidad VARCHAR(20),
    FOREIGN key (id_insumo) REFERENCES insumos(id_insumo)
);

CREATE TABLE proveedores(
    id_proveedor BIGINT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    rfc VARCHAR(100),
    direccion VARCHAR(100)
);

CREATE TABLE almacenes(
    id_almacen BIGINT PRIMARY KEY AUTO_INCREMENT,
    decripcion VARCHAR(100),
    direccion VARCHAR(100)
);

CREATE TABLE entradas(
    id_entrada BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_almacen BIGINT ,
    id_insumo BIGINT ,
    id_proveedor BIGINT ,
    id_compra BIGINT ,
    fecha_entrada DATETIME,
    cantidad FLOAT,
    importe FLOAT,
    precio_unitario Float,
    FOREIGN KEY (id_almacen) REFERENCES almacenes(id_almacen),
    FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo),
    FOREIGN KEY (id_proveedor) REFERENCES proveedores(id_proveedor),
    FOREIGN KEY (id_compra) REFERENCES requisicion_compras(id_compra)
    
);
CREATE TABLE inventario(
    id_inventario BIGINT primary KEY AUTO_INCREMENT,
    id_insumo BIGINT ,
    id_entrada BIGINT ,
    cantidad FLOAT,
    FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo),
    FOREIGN KEY (id_entrada) REFERENCES entradas(id_entrada)

);
CREATE TABLE requisiciones_insumo(
    id_requisicion BIGINT PRIMARY KEY AUTO_INCREMENT,
    numero INT,
    fecha DATETIME,
    solicitante VARCHAR(100),
    revisor VARCHAR(100),
    autorizante VARCHAR(100),
    id_insumo BIGINT ,
    cantidad FLOAT,
    observaciones VARCHAR(100),
    centro_costo VARCHAR(20),
    prioridad VARCHAR(20),
    unidad VARCHAR(20),
    FOREIGN KEY(id_insumo) REFERENCES insumos(id_insumo)
);
CREATE TABLE estructuras(
   id_estructura BIGINT PRIMARY KEY AUTO_INCREMENT,
   descripcion VARCHAR(100),
    id_insumo BIGINT ,
    cantidad FLOAT,
    FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo)
);

CREATE TABLE modulos(
    id_modulo  BIGINT PRIMARY KEY AUTO_INCREMENT, 
    descripcion VARCHAR(100),
    id_estructura BIGINT ,
    insumo_modulo FLOAT,
    FOREIGN KEY (id_estructura)REFERENCES estructuras(id_estructura)
);
CREATE TABLE roles(
    id_rol BIGINT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(100)
);
CREATE TABLE usuarios(
    id_usuario BIGINT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    id_rol  BIGINT ,
    ultima_entrada DATETIME,
    FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

INSERT INTO `partidas` (`id_partida`, `descripcion`) VALUES
(1, 'carpinteria');

INSERT INTO `insumos` (`id_insumo`, `clave`, `descripcion`, `id_partida`, `unidad_medida`) VALUES
(1, 'abc', 'tablas', 1, 'metros');

  INSERT INTO `listainsumo` (`id_Listainsumo`, `id_insumo`, `proyecto`,`cantidad`,`status`) VALUES
(1,1, 'A1',20,1);

INSERT INTO `requisicion_compras` (`id_compra`, `id_insumo`, `fecha`, `cantidad`, `comprador`, `numero`, `solicitante`, `revisor`, `autorizante`, `observaciones`, `centro_costo`, `prioridad`, `unidad`) VALUES
(1, 1, '2021-05-31 00:22:20', 20, 'pedro', 5, 'carlos', 'pablo', 'pablo', 'ninguna', '20', 'ordinaria', '20');

INSERT INTO `proveedores` (`id_proveedor`, `nombre`, `rfc`, `direccion`) VALUES
(1, 'algunadelaciudad', 'adlc546498', 'algunade la ciudad');

 INSERT INTO `almacenes` (`id_almacen`, `decripcion`, `direccion`) VALUES
(1, 'almacen 1', 'en alguna parte de la ciudad');


INSERT INTO `entradas` (`id_entrada`, `id_almacen`, `id_insumo`, `id_proveedor`, `id_compra`, `fecha_entrada`, `cantidad`, `importe`,`precio_unitario`) VALUES
(1, 1, 1, 1, 1, '2021-05-31 00:27:40', 20, 80,5);


INSERT INTO `inventario` (`id_inventario`, `id_insumo`, `id_entrada`, `cantidad`) VALUES
(1, 1, 1, 80);

INSERT INTO `requisiciones_insumo` (`id_requisicion`, `numero`, `fecha`, `solicitante`, `revisor`, `autorizante`, `id_insumo`, `cantidad`, `observaciones`, `centro_costo`, `prioridad`, `unidad`) VALUES
(1, 4, '2021-05-31 00:31:37', 'pedro', 'juan', 'carlos', 1, 40, 'ninguna', 'insumo', 'ordinaria', 'metros');

INSERT INTO `estructuras` (`id_estructura`, `descripcion`, `id_insumo`, `cantidad`) VALUES
(1, 'estructura 1', 1, 80);

INSERT INTO `modulos` (`id_modulo`, `descripcion`, `id_estructura`, `insumo_modulo`) VALUES
(1, 'modulo g1', 1, 40);
INSERT INTO `roles` (`id_rol`, `descripcion`) VALUES
(1, 'almacenista');

INSERT INTO `usuarios` (`id_usuario`, `nombre`, `apellido`, `id_rol`, `ultima_entrada`) VALUES
(1, 'arturo', 'lopez', 1, '2021-05-31 00:36:24');
------

 
  /*reportes almacenita>
        Insumos en alamacen  [nombre cautos entraron salieron   preciounitario  importe[perciounit * cantidad]]    fecha de entrada     uso por modulo 
            salida

            gestion de insumos   si alcanso*/














