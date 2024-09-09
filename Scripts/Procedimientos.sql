if object_id('dbo.Usp_Tb_Demo_Ins') is not null
  drop procedure dbo.Usp_Tb_Demo_Ins
go

create procedure dbo.Usp_Tb_Demo_Ins
  @nombre varchar(40)
  , @precio decimal(16,2)
  
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Demo_Ins "laptop Gamer", 5000
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if not exists( select id from dbo.Tb_Demo where nombre = @nombre)  
  begin  
    insert into 
        dbo.Tb_Demo 
        (nombre
        , precio
        , estatus)
      values 
        ( @nombre
        , @precio
        
        , 1
        )
  
    select [id]=@@identity
    
  end
  else
  begin
    select [id]= 0
  end
end
go

if object_id('dbo.Usp_Tb_Demo_Obt') is not null
  drop procedure dbo.Usp_Tb_Demo_Obt
go

create procedure dbo.Usp_Tb_Demo_Obt
as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Demo_Obt
 
*/
begin 
  declare
    @Activo int
  set
    @Activo = 1
  select
    pr.id
    , pr.nombre
    , pr.precio
    , pr.estatus

  from
    dbo.Tb_Demo pr
  
end
go

if object_id('dbo.Usp_Tb_Demo_Eli') is not null
  drop procedure dbo.Usp_Tb_Demo_Eli
go 

create procedure dbo.Usp_Tb_Demo_Eli
  @id int

as
/*
 18/08/24 Jose Razo  Creacion
 
 --Ejecucion
 
 exec dbo.Usp_Tb_Demo_Eli 1
 
*/
begin 
  declare
    @Inactivo int
  set
    @Inactivo = 0
    
  if exists ( select id from dbo.Tb_Demo where id = @id)  
  begin  
    update 
      dbo.Tb_Demo
    set
      estatus = @Inactivo 

    where
      id = @id  
    select [id]=@id    
  end
  else
  begin
    select [id]= 0
  end
end
go
