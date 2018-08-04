/** Carga inicial para ambientes de Desenvolvimento e testes **/
USE [TrabalhoEmFoco]
GO

insert into usuario values ('super', 'super@trabalhoemfoco', 'teste', 1);
insert into usuario values ('Administrador', 'administrador@trabalhoemfoco', 'teste', 2);
insert into usuario values ('Colaborador', 'colaborador@trabalhoemfoco', 'teste', 3);
insert into usuario values ('Aluno', 'aluno@trabalhoemfoco', 'teste', 4);

insert into Perfil values ('Super Administrador');
insert into Perfil values ('Administrador');
insert into Perfil values ('Colaborador');
insert into Perfil values ('Aluno');
