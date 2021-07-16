CREATE DATABASE almacen;
USE almacen;

CREATE TABLE proyecto(
    id_proyecto BIGINT primary key AUTO_INCREMENT,
    descripcion VARCHAR(300)
)
CREATE TABLE partidas(
    id_partida BIGINT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(500),
    status CHAR(1)
);

CREATE TABLE insumos(
    id_insumo BIGINT PRIMARY KEY AUTO_INCREMENT,
    clave VARCHAR(20),
    descripcion VARCHAR(70),
    id_partida BIGINT,
    unidad_medida VARCHAR (10),
    status CHAR(1),
    FOREIGN KEY(id_partida) REFERENCES partidas(id_partida));


CREATE TABLE estructuras(
   id_estructura BIGINT PRIMARY KEY AUTO_INCREMENT,
   descripcion VARCHAR(100),
    id_insumo BIGINT ,
    cantidad FLOAT,
    status CHAR(1),
    FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo)
);

CREATE TABLE proveedores(
    id_proveedor BIGINT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    rfc VARCHAR(100),
    direccion VARCHAR(100),
    status CHAR(1)
);

CREATE TABLE modulos(
    id_modulo  BIGINT PRIMARY KEY AUTO_INCREMENT, 
    id_proyecto BIGINT,
    descripcion VARCHAR(100),
    id_estructura BIGINT ,
    insumo_modulo FLOAT,
    id_insumo BIGINT ,
    status CHAR(1),
     FOREIGN KEY(id_proyecto) REFERENCES proyecto(id_proyecto)
     FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo)
    FOREIGN KEY (id_estructura)REFERENCES estructuras(id_estructura)
);

CREATE TABLE lista_solicitud_insumo(
    id_lsi BIGINT PRIMARY KEY AUTO_INCREMENT,
    fechacreacion DATETIME,
    status CHAR(1),
    );
CREATE TABLE listainsumo(
    id_listainsumo BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_insumo BIGINT ,
    cantidad FLOAT,
    status CHAR(1),
    id_modulo BIGINT,
    id_lsi BIGINT,
    FOREIGN KEY(id_modulo) REFERENCES modulos(id_modulo),
    FOREIGN key (id_insumo) REFERENCES insumos(id_insumo),
    FOREIGN key (id_lsi) REFERENCES lista_solicitud_insumo(id_lsi)
   
    );



CREATE TABLE lista_req_compra(
    id_lrc BIGINT PRIMARY KEY AUTO_INCREMENT,
    fechacreacion DATETIME,
    status CHAR(1));

CREATE TABLE requisicion_compras(
    id_compra BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_insumo BIGINT ,
    id_proveedor BIGINT,
    id_modulo BIGINT,
    id_lrc BIGINT,
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
    status CHAR(1),
    FOREIGN key (id_lrc) REFERENCES lista_req_compra(id_lrc)
    FOREIGN KEY(id_modulo) REFERENCES modulos(id_modulo),
    FOREIGN KEY(id_proveedor) REFERENCES proveedores(id_proveedor),
    FOREIGN key (id_insumo) REFERENCES insumos(id_insumo)
);




CREATE TABLE almacenes(
    id_almacen BIGINT PRIMARY KEY AUTO_INCREMENT,
    decripcion VARCHAR(100),
    direccion VARCHAR(100),
    status CHAR(1)
);

CREATE TABLE entradas(
    id_entrada BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_almacen BIGINT ,
    id_insumo BIGINT ,
    id_proveedor BIGINT ,
    id_compra BIGINT ,
    fecha DATETIME,
    cantidad FLOAT,
    importe FLOAT,
    precio_unitario Float,
    status CHAR(1),
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
    status CHAR(1),
    FOREIGN KEY (id_insumo) REFERENCES insumos(id_insumo),
    FOREIGN KEY (id_entrada) REFERENCES entradas(id_entrada)

);

CREATE TABLE lista_req_insumos(
    id_lri BIGINT PRIMARY KEY AUTO_INCREMENT,
    fechacreacion DATETIME,
    status CHAR(1));

CREATE TABLE requisiciones_insumo(
    id_requisicion BIGINT PRIMARY KEY AUTO_INCREMENT,
    id_lri BIGINT,
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
    status CHAR(1),
    id_modulo BIGINT,
     FOREIGN KEY(id_lri) REFERENCES lista_req_insumos(id_lri)
    FOREIGN KEY(id_insumo) REFERENCES insumos(id_insumo)
    FOREIGN KEY(id_modulo) REFERENCES modulos(id_modulo)
);






CREATE TABLE roles(
    id_rol BIGINT PRIMARY KEY AUTO_INCREMENT,
    descripcion VARCHAR(100),
    status CHAR(1)
);
CREATE TABLE usuarios(
    id_usuario BIGINT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100),
    apellido VARCHAR(100),
    id_rol  BIGINT ,
    ultima_entrada DATETIME,
    status CHAR(1),
    FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);
