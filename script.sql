-- Criação do banco de dados
CREATE DATABASE CVA;
GO

-- Seleção do banco de dados
USE CVA;
GO

-- Criação da tabela tb_paciente
CREATE TABLE dbo.tb_paciente (
    id_paciente INT IDENTITY PRIMARY KEY,
    dsc_nome VARCHAR(MAX) NOT NULL,
    dat_nascimento DATETIME NOT NULL,
    dat_criacao DATETIME NOT NULL
);
GO

-- Criação da tabela tb_agendamento
CREATE TABLE dbo.tb_agendamento (
    id_agendamento INT IDENTITY PRIMARY KEY,
    id_paciente INT NOT NULL,
    dat_agendamento DATE NOT NULL,
    hor_agendamento TIME NOT NULL,
    dsc_status VARCHAR(50) NOT NULL,
    dat_criacao DATETIME NOT NULL,
    CONSTRAINT FK_Agendamento_Paciente FOREIGN KEY (id_paciente)
    REFERENCES dbo.tb_paciente (id_paciente)
);
GO
