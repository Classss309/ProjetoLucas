-- ============================================================
-- Hotel California — Script de Banco de Dados
-- Banco: gs600hotelCalifornia
-- Execução idempotente: pode ser rodado várias vezes
-- ============================================================

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'gs600hotelCalifornia')
    CREATE DATABASE gs600hotelCalifornia;
GO

USE gs600hotelCalifornia;
GO

-- Drop das tabelas em ordem de FK (filhos antes dos pais)
IF OBJECT_ID('tblReserva',  'U') IS NOT NULL DROP TABLE tblReserva;
IF OBJECT_ID('tblHotel',    'U') IS NOT NULL DROP TABLE tblHotel;
IF OBJECT_ID('tblHospede',  'U') IS NOT NULL DROP TABLE tblHospede;
IF OBJECT_ID('tblEndereco', 'U') IS NOT NULL DROP TABLE tblEndereco;
GO

-- ============================================================
-- tblEndereco
-- ============================================================
CREATE TABLE tblEndereco (
    IdEndereco  INT           IDENTITY(1,1) PRIMARY KEY,
    Logradouro  VARCHAR(150)  NOT NULL,
    Numero      VARCHAR(10)   NOT NULL,
    Complemento VARCHAR(50)   NULL,
    Bairro      VARCHAR(80)   NOT NULL,
    Cidade      VARCHAR(80)   NOT NULL,
    Estado      CHAR(2)       NOT NULL,
    CEP         CHAR(9)       NOT NULL
);

-- ============================================================
-- tblHospede
-- ============================================================
CREATE TABLE tblHospede (
    IdHospede      INT           IDENTITY(1,1) PRIMARY KEY,
    Nome           VARCHAR(150)  NOT NULL,
    CPF            CHAR(14)      NOT NULL,
    RG             VARCHAR(20)   NULL,
    Telefone       VARCHAR(20)   NULL,
    Email          VARCHAR(100)  NULL,
    DataNascimento DATE          NOT NULL,
    Nacionalidade  VARCHAR(60)   NOT NULL,
    Ativo          BIT           NOT NULL DEFAULT 1
);

-- ============================================================
-- tblHotel (Filiais)
-- ============================================================
CREATE TABLE tblHotel (
    IdFilial    INT            IDENTITY(1,1) PRIMARY KEY,
    RazaoSocial VARCHAR(150)   NOT NULL,
    CNPJ        CHAR(18)       NOT NULL,
    Telefone    VARCHAR(20)    NULL,
    Email       VARCHAR(100)   NULL,
    Avaliacao   DECIMAL(3,1)   NULL,
    IdEndereco  INT            NULL REFERENCES tblEndereco(IdEndereco),
    Ativo       BIT            NOT NULL DEFAULT 1
);

-- ============================================================
-- tblReserva
-- ============================================================
CREATE TABLE tblReserva (
    IdReserva    INT            IDENTITY(1,1) PRIMARY KEY,
    IdHospede    INT            NOT NULL REFERENCES tblHospede(IdHospede),
    IdFilial     INT            NOT NULL REFERENCES tblHotel(IdFilial),
    NumeroQuarto INT            NOT NULL,
    TipoQuarto   VARCHAR(50)    NOT NULL,
    DataCheckin  DATE           NOT NULL,
    DataCheckout DATE           NOT NULL,
    ValorDiaria  DECIMAL(10,2)  NOT NULL,
    Observacoes  VARCHAR(300)   NULL,
    Status       VARCHAR(20)    NOT NULL DEFAULT 'Ativa'
);
GO

-- ============================================================
-- Dados de exemplo
-- ============================================================
INSERT INTO tblEndereco (Logradouro, Numero, Complemento, Bairro, Cidade, Estado, CEP)
VALUES
    ('Avenida Paulista',     '1578', 'Sala 3',  'Bela Vista', 'São Paulo', 'SP', '01310100'),
    ('Rua das Flores',       '220',  NULL,      'Centro',     'Curitiba',  'PR', '80010020'),
    ('Travessa do Comércio', '45',   'Bloco B', 'Comércio',   'Salvador',  'BA', '40015130');

INSERT INTO tblHospede (Nome, CPF, RG, Telefone, Email, DataNascimento, Nacionalidade, Ativo)
VALUES
    ('Carlos Eduardo Lima', '123.456.789-00', '12.345.678-9', '(11) 91234-5678', 'carlos@email.com', '1985-03-15', 'Brasileira', 1),
    ('Ana Paula Ferreira',  '987.654.321-00', '98.765.432-1', '(41) 98765-4321', 'ana@email.com',    '1992-07-22', 'Brasileira', 1),
    ('John Robert Smith',   '000.111.222-33', NULL,            '(21) 99000-1111', 'john@email.com',   '1978-11-05', 'Americana',  1);

INSERT INTO tblHotel (RazaoSocial, CNPJ, Telefone, Email, Avaliacao, IdEndereco, Ativo)
VALUES
    ('Hotel California São Paulo Ltda.', '12.345.678/0001-99', '(11) 3333-4444', 'sp@hotelcalifornia.com',  4.5, 1, 1),
    ('Hotel California Curitiba Ltda.',  '98.765.432/0001-11', '(41) 2222-3333', 'cwb@hotelcalifornia.com', 4.0, 2, 1),
    ('Hotel California Salvador Ltda.',  '55.444.333/0001-22', '(71) 4444-5555', 'ssa@hotelcalifornia.com', 3.5, 3, 1);

INSERT INTO tblReserva (IdHospede, IdFilial, NumeroQuarto, TipoQuarto, DataCheckin, DataCheckout, ValorDiaria, Observacoes, Status)
VALUES
    (1, 1, 101, 'Suíte',   '2026-02-10', '2026-02-14', 350.00, 'Cama king size',   'Ativa'),
    (2, 2, 205, 'Duplo',   '2026-02-15', '2026-02-17', 180.00, NULL,               'Concluída'),
    (3, 3, 310, 'Simples', '2026-03-01', '2026-03-03', 120.00, 'Vista para o mar', 'Ativa');
GO

-- Verificação
SELECT * FROM tblEndereco;
SELECT * FROM tblHospede;
SELECT * FROM tblHotel;
SELECT * FROM tblReserva;
GO
