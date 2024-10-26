if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LivroAssunto') and o.name = 'FK_LIVROASS_ASSUNTOLI_ASSUNTO')
alter table LivroAssunto
   drop constraint FK_LIVROASS_ASSUNTOLI_ASSUNTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LivroAssunto') and o.name = 'FK_LIVROASS_LIVROASSU_LIVRO')
alter table LivroAssunto
   drop constraint FK_LIVROASS_LIVROASSU_LIVRO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LivroAutor') and o.name = 'FK_LIVROAUT_AUTORLIVR_AUTOR')
alter table LivroAutor
   drop constraint FK_LIVROAUT_AUTORLIVR_AUTOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LivroAutor') and o.name = 'FK_LIVROAUT_LIVROAUTO_LIVRO')
alter table LivroAutor
   drop constraint FK_LIVROAUT_LIVROAUTO_LIVRO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Assunto')
            and   type = 'U')
   drop table Assunto
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Autor')
            and   type = 'U')
   drop table Autor
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Livro')
            and   type = 'U')
   drop table Livro
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LivroAssunto')
            and   name  = 'LIVROASSUNTO_FK'
            and   indid > 0
            and   indid < 255)
   drop index LivroAssunto.LIVROASSUNTO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LivroAssunto')
            and   name  = 'ASSUNTOLIVRO_FK'
            and   indid > 0
            and   indid < 255)
   drop index LivroAssunto.ASSUNTOLIVRO_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LivroAssunto')
            and   type = 'U')
   drop table LivroAssunto
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LivroAutor')
            and   name  = 'AUTORLIVRO_FK'
            and   indid > 0
            and   indid < 255)
   drop index LivroAutor.AUTORLIVRO_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('LivroAutor')
            and   name  = 'LIVROAUTOR_FK'
            and   indid > 0
            and   indid < 255) 
   drop index LivroAutor.LIVROAUTOR_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LivroAutor')
            and   type = 'U')
   drop table LivroAutor
go

/*==============================================================*/
/* Table: Assunto                                               */
/*==============================================================*/
create table Assunto (
   CodAss               int                  not null identity(1, 1),
   Descricao            varchar(80)          not null,
   constraint PK_ASSUNTO primary key (CodAss)
)
go

/*==============================================================*/
/* Table: Autor                                                 */
/*==============================================================*/
create table Autor (
   CodAu                int                  not null identity(1, 1),
   Nome                 varchar(100)          not null,
   constraint PK_AUTOR primary key (CodAu)
)
go

/*==============================================================*/
/* Table: Livro                                                 */
/*==============================================================*/
create table Livro (
   Cod                  int                  not null identity(1, 1),
   Titulo               varchar(100)          not null,
   Editora              varchar(100)          not null,
   Edicao               int                  not null,
   AnoPublicacao        int             not null,
   constraint PK_LIVRO primary key (Cod)
)
go

/*==============================================================*/
/* Table: LivroAssunto                                          */
/*==============================================================*/
create table LivroAssunto (
   LivroCod                  int                  not null,
   AssuntoCodAss               int                  not null,
   constraint PK_LIVROASSUNTO primary key (LivroCod, AssuntoCodAss)
)
go

/*==============================================================*/
/* Index: ASSUNTOLIVRO_FK                                       */
/*==============================================================*/




create nonclustered index ASSUNTOLIVRO_FK on LivroAssunto (CodAss ASC)
go

/*==============================================================*/
/* Index: LIVROASSUNTO_FK                                       */
/*==============================================================*/




create nonclustered index LIVROASSUNTO_FK on LivroAssunto (Cod ASC)
go

/*==============================================================*/
/* Table: LivroAutor                                            */
/*==============================================================*/
create table LivroAutor (
   AutorCodAu           int                  not null,
   LivroCod             int                  not null,
   constraint PK_LIVROAUTOR primary key (AutorCodAu, LivroCod)
)
go

/*==============================================================*/
/* Index: LIVROAUTOR_FK                                         */
/*==============================================================*/




create nonclustered index LIVROAUTOR_FK on LivroAutor (LivroCod ASC)
go

/*==============================================================*/
/* Index: AUTORLIVRO_FK                                         */
/*==============================================================*/




create nonclustered index AUTORLIVRO_FK on LivroAutor (AutorCodAu ASC)
go

alter table LivroAssunto
   add constraint FK_LIVROASS_ASSUNTOLI_ASSUNTO foreign key (CodAss)
      references Assunto (CodAss)
go

alter table LivroAssunto
   add constraint FK_LIVROASS_LIVROASSU_LIVRO foreign key (Cod)
      references Livro (Cod)
go

alter table LivroAutor
   add constraint FK_LIVROAUT_AUTORLIVR_AUTOR foreign key (AutorCodAu)
      references Autor (CodAu)
go

alter table LivroAutor
   add constraint FK_LIVROAUT_LIVROAUTO_LIVRO foreign key (LivroCod)
      references Livro (Cod)
go

