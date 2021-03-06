use master
go 

if DB_ID('PowerMonitor') is not null
	drop database PowerMonitor;
GO

create database PowerMonitor;
GO

use PowerMonitor
gO	

if OBJECT_ID('userDistribution') is not null
	drop table dbo.userDistribution

if OBJECT_ID('UserRole') is not null
	drop table dbo.UserRole;
	
if OBJECT_ID('RolePermission') is not null
	drop table dbo.RolePermission;

if OBJECT_ID('Users') is not null
	drop table dbo.Users;
	
if OBJECT_ID('Permission') is not null
	drop table dbo.Permission;

if OBJECT_ID('Roles') is not null
	drop table dbo.Roles
	
create table dbo.Users(
	userid int
	,userName nvarchar(200) 
	,loginName nvarchar(200)
	,passwd nvarchar(200)
	,active char(1)
	,maxDevices int
	constraint PK_users primary key(userId)
	);
	
create index idx_users on dbo.Users(loginName);
	


create table dbo.Permission(
	permId int
	,permDesc nvarchar(2000)
	,active char(1)
	,constraint PK_Permission primary key (permId)
	);
	

	
create table dbo.Roles(
	roleId int  
	,roleName nvarchar(200)
	,roleDesc nvarchar(2000)
	,active char(1)
	,constraint PK_Roles primary key (roleId)
	);
	

	
create table dbo.RolePermission(
	roleId int
	,permId int
	,constraint FK_RolePermission_roleId_Role foreign key (roleId) references dbo.Roles(roleId)
	,constraint FK_RolePermission_permId_Perm foreign key(permId) references dbo.Permission(permId)
	);
create clustered index idx_RolePermission on dbo.RolePermission(roleId);
	

	
create table dbo.UserRole(
	userId int,
	roleId int
	,constraint FK_UserRole_userId_users foreign key(userId) references dbo.Users(userId)
	,constraint FK_UserRole_roleId_roles foreign key(roleId) references dbo.Roles(roleId)
	);
	
create clustered index idx_userrole_userid_roleid on dbo.UserRole(userId,roleId);
	
--power system related tables
	
insert into dbo.Roles(roleId,roleDesc,active) values
	(1,'超级管理员','Y')
	,(2,'管理员','Y')
	,(3,'操作员','Y');
	
insert into dbo.Permission(permId,permDesc,active) values
	(1,'配电室增删改','A')
	,(2,'用户增删改','A')
	,(3,'设备增删改','A')
	,(4,'设备连接状态','A')
	,(5,'设备实时状态','A')
	,(6,'告警状态监控','A')
	,(7,'历史查询','A')
	,(8,'日志查询','A')
	,(9,'修改密码','A')
	,(10,'配电室昵称','A')
	
insert into dbo.Users(userid,userName,passwd,loginName,active) values
(1,'super','123456','super','A')
,(2,'admin','123456','admin','A')
,(3,'ope','123456','ope','A')

insert into dbo.UserRole(userId,roleId) values
(1,1),(2,2),(3,3)
	
insert into dbo.RolePermission(roleId,permId) values
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),(1,7),(1,8),(1,9)

insert into dbo.RolePermission(roleId,permId) values
(2,3),(2,9),(2,10)

insert into dbo.RolePermission(roleId,permId) values
(3,9),(3,4),(3,5),(3,6),(3,7),(3,8)

--PowerMonitor related tables & data
if OBJECT_ID('deviceMonitor') is not null
	drop table dbo.deviceMonitor;
	
if OBJECT_ID('distDevice') is not null
	drop table dbo.distDevice;
	
if OBJECT_ID('deviceIdentifier') is not null
	drop table dbo.deviceIdentifier;
	
if OBJECT_ID('distribution') is not null
	drop table dbo.distribution;
	


if OBJECT_ID('device') is not null
	drop table dbo.device;
	
create table distribution(
	distId int identity(1,1)
	,distName nvarchar(200)
	,nickName nvarchar(200)
	,distAddress nvarchar(2000)
	,distDesc nvarchar(2000)
	,contact_primary nvarchar(200)
	,phoneNumber_primary nvarchar(200)
	,contact_bak1 nvarchar(200)
	,phoneNumber_bak1 nvarchar(200)
	,contact_bak2 nvarchar(200)
	,phoneNumber_bak2 nvarchar(200)
	,constraint PK_distribution primary key(distId)
	,constraint UQ_distName unique(distName)
	);
create index idx_distribution on dbo.distribution(distId);
	
create table dbo.device(
	devId int identity(1,1)
	,devName nvarchar(200)
	,addressCode nvarchar(200)
	,current_max decimal(5,2)
	,current_warning decimal(5,2)
	,voltage_warning_high decimal(10,2)
	,voltage_warning_low decimal(10,2)
	,devStatus char(1)
	,distId int
	,constraint PK_device primary key (devId)
	--,constraint Unique_devName UNIQUE(devName)--同一配电室下不能重复
	--,constraint Unique_addresscode unique(addressCode)
	);
	
create unique index idx_device on dbo.device(addressCode);
create index idx_device_distId on dbo.device(distId,devId);
	

	
create table dbo.userDistribution(
	userId int
	,distId int
	,constraint PK_userDistribution primary key(userId,distId)
	,constraint FK_userDistribution_userId foreign key(userId) references dbo.users(userId)
	,constraint FK_userDistribution_distId foreign key(distId) references dbo.distribution(distId)
	);
	
create index idx_userDistribution_distId on dbo.userDistribution(distId,userId);
	
create table dbo.deviceMonitor(
	statusDate datetime
	,devId int
	,voltage_A int
	,voltage_B int
	,voltage_C int
	,voltage_AB int
	,voltage_CA int
	,voltage_BC int
	,current_A int
	,current_B int
	,current_C int
	,realPower_A int
	,realPower_B int
	,realPower_C int
	,realPower_total int
	,reactivePower_A int
	,reactivePower_B int
	,reactivePower_C int
	,reactivePower_total int
	,apparentPower_total int
	,powerFactor decimal(3,2)
	,frequency decimal(3,2)
	,activePowerEnergy_pos decimal(10,2)
	,activePowerEnergy_neg decimal(10,2)
	,reactivePowerEnergy_pos decimal(10,2)
	,reactivePowerEnergy_neg decimal(10,2)
	,switchValue int
	);
	
create clustered index idx_deviceMonitor on dbo.deviceMonitor(statusDate);
create index idx_deviceMonitor_devId on dbo.deviceMonitor(devId);
	
if OBJECT_ID('deviceWarning') is not null
	drop table dbo.deviceWarning;
	
if OBJECT_ID('deviceWarningHistory') is not null
	drop table dbo.deviceWarningHistory;
	
	
create table dbo.deviceWarning(--device latest warning
	devId int
	,warningTime datetime
	,warningType tinyint--1，开关量 2-4 三个电流 3-7 三个线电压
	,warningValue nvarchar(100)
	,warningContent nvarchar(1000)
	,processTime datetime
	,processBy int
	,disableTime int --in minutes, don't show this warning
	);
	
create clustered index idx_deviceWarning on dbo.deviceWarning(devId);
	
create table dbo.deviceWarningHistory(--device warning history
	devId int
	,warningType tinyint
	,warningValue nvarchar(100)
	,warningTime datetime
	,warningContent nvarchar(1000)
	,processTime datetime
	,processBy int
	,disabletime int
	);
create clustered index idx_deviceWarning_warningTime on dbo.deviceWarningHistory(warningTime);
create index idx_deviceWarning_devId on dbo.deviceWarningHistory(devId,warningType,warningTime);
	
if OBJECT_ID('transactionLog') is not null
	drop table dbo.transactionLog;
	
if OBJECT_ID('process') is not null
	drop table dbo.process
	
create table dbo.process(
		processId int
		,processDesc nvarchar(2000)
		,constraint PK_process primary key(processId)
	)	;
	
create table dbo.transactionLog(
	logId bigint identity(1,1)
	,processId int
	,userId int --user do the operation
	,logdate datetime
	,devAddressCode nvarchar(200) --for device operation only
	,constraint PK_logId  primary key nonclustered(logId)
	,constraint FK_transactionLog_process foreign key(processId) references dbo.process(processId)
	);
	
create clustered index idx_transactionLog_logdate on dbo.transactionLog(logdate);
create index idx_transactionLog_userId on dbo.transactionLog(userId);
create index idx_transactionLog_devAddressCode on dbo.transactionLog(devAddressCode);
	
create table dbo.config(
	configString nvarchar(200)
	,configValue nvarchar(200)
	,configDesc nvarchar(2000)
	)

insert into dbo.config(configString,configValue,configDesc) values
('saveDBInterval','1','minutes')
,('warningType','1','1 声音 2 窗口')
	



