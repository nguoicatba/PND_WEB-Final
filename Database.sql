Create database data_PND;
use data_PND;


create table tbl_DEPARTMENT(
	Department_ID nvarchar(20) not null primary key,
	Dep_name nvarchar(255),
);

insert into tbl_DEPARTMENT(Department_ID, Dep_name) values ('DOC',N'Phòng chừng từ');
insert into tbl_DEPARTMENT(Department_ID, Dep_name) values ('KT',N'Phòng kế toán');
insert into tbl_DEPARTMENT(Department_ID, Dep_name) values ('LGT',N'Phòng logistic');
insert into tbl_DEPARTMENT(Department_ID, Dep_name) values ('SALE',N'Phòng kinh doanh');
insert into tbl_DEPARTMENT(Department_ID, Dep_name) values ('CEO',N'Quản lý');

create table tbl_TAI_KHOAN(
	Username nvarchar(50) not null primary key,
	Passwords nvarchar(20),
	Statuss nvarchar(50),
	createDate datetime,
	Staff_name nvarchar(255),
	DOB datetime,
	Department_ID nvarchar(20) foreign key references tbl_DEPARTMENT(Department_ID),
);

insert into tbl_TAI_KHOAN(Username,Passwords,Statuss,createDate,Staff_name,DOB,Department_ID) 
values ('a','123','off',2025/3/19,'Cao Trần Hưng', 2003/11/13,'Doc');

create table tbl_ChucNang(
	ID_ChucNang int not null primary key identity(1,1),
	ChucNang nvarchar(255),
);

insert into tbl_ChucNang (ChucNang) values ('JOB');
insert into tbl_ChucNang (ChucNang) values ('HSCODE');
insert into tbl_ChucNang (ChucNang) values ('QUOTATION');
insert into tbl_ChucNang (ChucNang) values ('TUTT');
insert into tbl_ChucNang (ChucNang) values ('AGENT');
insert into tbl_ChucNang (ChucNang) values ('CNEE');
insert into tbl_ChucNang (ChucNang) values ('SHIPPER');
insert into tbl_ChucNang (ChucNang) values ('CARRIER');
insert into tbl_ChucNang (ChucNang) values ('PORT');
insert into tbl_ChucNang (ChucNang) values ('CUSTOMER');
insert into tbl_ChucNang (ChucNang) values ('CURRENCY');

create table tbl_DEPARTMENT_ChucNang(
	Department_ID nvarchar(20) foreign key references tbl_DEPARTMENT(Department_ID),
	ID_ChucNang int foreign key references tbl_ChucNang(ID_ChucNang),
	Primary key(Department_ID,ID_ChucNang)
)

insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',1);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',2);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',3);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',4);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',5);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',6);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',7);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',8);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',9);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',10);
insert into tbl_DEPARTMENT_ChucNang(Department_ID, ID_ChucNang) values ('DOC',11);



create table tbl_CUSTOMER(
	Customer_ID nvarchar(20) not null primary key,  -- mã số thuế công ty
	Company_Name nvarchar(255),
	Company_Namekd nvarchar(255),
	Com_Address nvarchar(1000),
	Com_Addresskd nvarchar(1000),
	Website nvarchar(255),
	Duty_Person nvarchar(255),
	Contact nvarchar(255),
	Email nvarchar(255),
);

insert into tbl_CUSTOMER(Customer_ID, Company_Name, Company_Namekd, Com_Address, Com_Addresskd, Website, Duty_Person, Contact, Email)
values ('123N456','NDK','Nade Death Kill','23P123 Acc','23P123 C123 China Thuong Hai','https://ndks','CHING','123901','ndkchina@gmail.com');

create table tbl_SUPPLIER(
	Supplier_ID nvarchar(50) not null primary key,
	Name_sup nvarchar(255),
	Typer nvarchar(20),
	Address_sup nvarchar(255),
	LCC_Fee nvarchar(255),
	Note nvarchar(255),

);

--insert into tbl_SUPPLIER(Supplier_ID, Name_sup,Typer,Address_sup,LCC_Fee, Note) 
--values ('123');

create table tbl_SUPPLIER_ACTION(
	ID int not null primary key identity(1,1),
	Supplier_ID nvarchar(50) foreign key references tbl_SUPPLIER(Supplier_ID),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	Note nvarchar(max)
);

--insert into tbl_SUPPLIER_ACTION(Supplier_ID, Person_in_charge, Phone_number,Email,Note)
--values ();

create table AGENT(
	CODE nvarchar(20) not null primary key,
	Agent_name nvarchar(1000),
	Agent_namekd nvarchar(1000),
	Agent_add nvarchar(255),
	Note nvarchar(max),
);

--insert into AGENT(CODE, Agent_name, Agent_namekd, Agent_add, Note)
--values();

create table AGENT_ACTION(
	ID int not null primary key identity(1,1),
	CODE nvarchar(20) foreign key references AGENT(CODE),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	Note nvarchar(max)
);

--insert into AGENT_ACTION(CODE,Person_in_charge,Phone_number, Email,Note)
--values();

create table CARRIER(
	CODE nvarchar(20) not null primary key,
	Carrier_name nvarchar(255),
	Carrier_namekd nvarchar(255),
	Carier_add nvarchar(255),
	Note nvarchar(max),
);

--insert into CARRIER(CODE,Carrier_name,Carrier_namekd,Carier_add,Note)
--values();

create table CARRIER_ACTION(
	ID int not null primary key identity(1,1),
	CODE nvarchar(20) foreign key references CARRIER(CODE),
	Person_in_charge nvarchar(255),
	Phone_number nvarchar(30),
	Email nvarchar(100),
	LCC_Fee nvarchar(255),
	Note nvarchar(1000),
);

--insert into CARRIER_ACTION(CODE,Person_in_charge,Phone_number,Email,LCC_Fee,Note)
--values();

create table tbl_SHIPPER(
	Shipper nvarchar(255) not null primary key,
	SAddress nvarchar(1000),
	SCity nvarchar(100),
	SPerson_in_charge nvarchar(255),
	TaxID	nvarchar(20),
);

create table tbl_CNEE(
	CNEE nvarchar(255) not null primary key,
	VCNEE nvarchar(255),			
	CAddress nvarchar(1000),
	VAddress nvarchar(1000),			
	CCity nvarchar(100),
	CPerson_in_charge nvarchar(255),
	TaxID	nvarchar(20),
	HAddress nvarchar(1000),
);

create table tbl_CNEE_ADD(
	ID int not null primary key identity(1,1),
	Adds nvarchar(500),
	Place nvarchar(255),
	PersonInCharge nvarchar(255),
	CNEE nvarchar(255) foreign key references tbl_CNEE(CNEE),
);

create table tbl_TUTT(
	SoTUTT nvarchar(50) not null primary key,
	Ngay datetime,
	NhanvienTUTT nvarchar(100),
	Username nvarchar(50),
	Noi_dung nvarchar(255),

	xacnhanduyet bit default 0,
	
	ketoan bit default 0,
	ceo bit default 0,
	Ghi_chu nvarchar(255),

);

create table tbl_TUTT_PHI(			-
	ID int not null primary key identity(1,1),
	SoHoaDon nvarchar(20),
	TenPhi nvarchar(255),
	TU bit DEFAULT 0,
	TT bit DEFAULT 0,
	SoTien float default 0,
	GhiChu nvarchar(255),

	SoTUTT nvarchar(50) foreign key references tbl_TUTT(SoTUTT),
);



create table tbl_JOB(
	Job_ID nvarchar(50) not null primary key,
	Goods_type nvarchar(20), 
	Job_date datetime default GETDATE() not null,
	MBL nvarchar(100),
	Issue_dateM datetime,
	OnBoard_dateM datetime,
	Vessel_name nvarchar(100),
	Voyage_name nvarchar(100),

	POL nvarchar(255), -- port of loading
	POD nvarchar(255), -- port of destination
	PODel nvarchar(255), -- port of deliver
	PODis nvarchar(255),  -- port of discharge
	PlaceofReceipt nvarchar(255),
	PlaceofDelivery nvarchar(255),
	
	Pre_Cariage_by nvarchar(100),
	
	ETD datetime not null,
	ETA datetime not null,

	Mode nvarchar(100),

	Agent nvarchar(20) foreign key references AGENT(CODE),
	Carrier nvarchar(20) foreign key references CARRIER(CODE),
	
	Ycompany nvarchar(1000),
	Link nvarchar(500),
	YunLock int DEFAULT 0,
	Use_time int DEFAULT 2025,
);




create table tbl_HBL(
	HBL nvarchar(50) not null primary key,
	Request_ID nvarchar(50) not null foreign key references tbl_JOB(Job_ID),
	Issue_placeH nvarchar(255),
	Issue_dateH datetime,
	OnBoard_dateH datetime,
	Customer_ID nvarchar(20) not null foreign key references tbl_CUSTOMER(Customer_ID),
	Shipper nvarchar(255) not null foreign key references tbl_SHIPPER(Shipper),
	CNEE nvarchar(255)not null foreign key references tbl_CNEE(CNEE),
	Notify_party nvarchar(255),
	
	BL_type nvarchar(100),
	Nom_Free nvarchar(100) not null,

	Cont_Seal_No nvarchar(1000),
	Volume nvarchar(255),
	Quantity nvarchar(255),
	Goods_desciption nvarchar(255) default 'AS PER BILL',
	Gross_weight float default 0,
	Tonnage float default 0,

	Customs_declaration_No nvarchar(100),
	Invoice_No nvarchar(50),

	NumberofOrigins nvarchar(100),
	Freight_Payable nvarchar(100),
	
	Mark_Nos nvarchar(1000),

	Freight_charge bit DEFAULT 0,
	Prepaid bit DEFAULT 0,
	Collect bit DEFAULT 0,

	SI_No nvarchar(20),

	PIC nvarchar(255),
	DO_date datetime,
	PIC_phone nvarchar(20),

);


create table tbl_PhanQuyenJOB(
Request_ID nvarchar(50) not null foreign key references tbl_JOB(Job_ID),
Username nvarchar(50) foreign key references tbl_TAI_KHOAN(Username),
Primary key(Request_ID,Username),
)



create table tbl_CONTH(
	ID int primary key not null identity(1,1),
	Cont_No nvarchar(255),
	HBL nvarchar(50) foreign key references tbl_HBL(HBL),
	Cont_quantity int default 0,
	Cont_type nvarchar(50),
	Seal_No nvarchar(255),
	Gross_weight float,
	CMB float,

	Goods_quantity nvarchar(255),
	Goods_depcription nvarchar(500),
);


create table KINDOFPACKAGES(
	CODE nvarchar(20) not null primary key,
	Package_name nvarchar(255),
	Packages_description nvarchar(255)
);

insert into KINDOFPACKAGES(CODE, Package_name) values
('BA', 'Barrels'),
('BE', 'Bundles'),
('BG', 'Bags'),
('BK', 'Baskets'),
('BL', 'Bales,compressed'),
('BN', 'Bales,non-compressed'),
('BR', 'Bars'),
('BX', 'Boxes'),
('CA', 'Cans, rectangular'),
('CG', 'Cages'),
('CK', 'Casks'),
('CL', 'Coils'),
('CN', 'Containers'),
('CO', 'Carboy, non-protected'),
('CP', 'Carboy, protected'),
('CR', 'Crates'),
('CS', 'Cases'),
('CT', 'Cartons'),
('CX', 'Cans, cylindrical'),
('CY', 'Cylinders'),
('DR', 'Drums'),
('KG', 'Kegs'),
('LG', 'Logs'),
('LZ', 'Logs, in bundle/bunch/truss'),
('MST', 'MST'),
('MT', 'Mats'),
('NE', 'Unpacked  or unpackaged'),
('NT', 'Nets'),
('PA', 'Packets'),
('PC', 'Parcels'),
('PE', 'Pens'),
('PG', 'Plates'),
('PI', 'Pipes'),
('PK', 'Packages'),
('PL', 'Pails'),
('PP', 'Pallets & Packages'),
('PS', 'Pieces'),
('PU', 'Trays'),
('RL', 'Rolls'),
('TY', 'Tanks'),
('ZZ', 'Others');


create table tbl_INVOICE(
	Debit_ID nvarchar(50) not null primary key,
	Invoice_type nvarchar(10) not null,
	Debit_date datetime default GETDATE(),
	Payment_date datetime,
	Invoice_No nvarchar(20),
	Invoice_date datetime,
	Supplier_ID nvarchar(50) foreign key references tbl_SUPPLIER(Supplier_ID),
	HBL nvarchar(50) foreign key references tbl_HBL(HBL),
);

create table tbl_CHARGES(
	ID int primary key not null identity(1,1),
	Debit_ID nvarchar(50) foreign key references tbl_INVOICE(Debit_ID),
	
	Exchange_rate real,
	Currency nvarchar(20), -- ngoại tệ
	
	Ser_Name nvarchar(255),
	Ser_Price real DEFAULT 0,
	Ser_Quantity real DEFAULT 0,
	Ser_Unit nvarchar(100),
	Ser_VAT real DEFAULT 0,
	M_VAT real DEFAULT 0,
	
	Buy bit DEFAULT 0,			    -- tiền mua
	Sell bit DEFAULT 0,				-- tiền bán
	Cont bit DEFAULT 0,				-- tiền cược cont
	Checked bit DEFAULT 0,			-- kiểm tra hóa đơn của kế toán
);

create table INVOICE_TYPE(
	Code nvarchar(10) not null primary key,
	Name_type nvarchar (255),
);

insert into INVOICE_TYPE(code, Name_type) values
('A', 'Agent'),
('C', 'CNEE'),
('S', 'Shipper'),
('O', 'Others'),
('V', 'Vendor');

create table FEE(
	CODE nvarchar(255) not null primary key,
	FEE nvarchar(255),
	UNIT nvarchar(255),
	NOTE nvarchar(255),
);
insert into FEE(CODE, FEE, UNIT)
values
('ACI',					N'Phí khai hải quan tự động', 'SET'),
('AFR FEE',				N'Phí khai hải quan', 'SET'),
('AFS FEE',				N'Phí khai sơ lược hàng hóa', 'SET'),
('AMENDMENT FEE',		N'Phí sửa vận đơn', 'SET'),
('AMS FEE',				N'Phí khai hải quan tự động', 'SET'),
('AWB',					N'Phí chứng từ hàng xuất', 'SET'),
('BAF',					N'Phụ phí nhiên liệu', 'CBM'),
('BAF FEE',				N'Phụ phí nhiên liệu', 'SHIPMENT'),
('BL FEE',				N'Phí chứng từ hàng xuất', 'SET'),
('BL FEE+SUR FEE',		N'Phí vận đơn và điện giao hàng', 'SET'),
('C/O FEE',				N'Phí CO', 'SET'),
('CAXE',				N'Phí lưu ca xe', 'SHIPMENT'),
('CFS',					N'Phí khai thác hàng lẻ', 'CBM'),
('CFS-2',				N'Phí khai thác hàng lẻ', 'SHIPMENT'),
('CIC',					N'Phí CIC', 'CBM'),
('CIC-20`DC',			N'Phí mất cân bằng container', '20`DC'),
('CIC-20`OT',			N'Phí mất cân bằng container', '20`OT'),
('CIC-20`FR',			N'Phí mất cân bằng container', '20`FR'),
('CIC-40`FR',			N'Phí mất cân bằng container', '40`FR'),
('CIC-40`HC',			N'Phí mất cân bằng container', '40`HC'),
('CIC-FCL',				N'Phí mất cân bằng container', 'CONT'),
('CIC-SHPT',			N'Phí mất cân bằng container', 'SHIPMENT'),
('CLEANING FEE',		N'Phí vệ sinh cont', 'CONT'),
('CLEANING FEE-20',		N'Phí vệ sinh cont', '20'),
('CLEANING FEE-40',		N'Phí vệ sinh cont', '40'),
('CLEANING FEE-SHPT',	N'Phí vệ sinh cont', 'SHIPMENT'),
('CUSTOM FEE',			'', ''),
('D/O',					N'Phí lệnh giao hàng', 'SHIPMENT'),
('DDP',					N'Phí DDP',	'SET'),
('DEM FEE',				N'Phí lưu container', 'SHIPMENT'),
('DTHC-20`DC',			N'Phí xếp dỡ cảng nhập', '20`DC'),
('DTHC-20`FR',			N'Phí xếp dỡ cảng nhập', '20`FR'),
('DTHC-20`OT',			N'Phí xếp dỡ cảng nhập', '20`OT'),
('DTHC-40',				N'Phí xếp dỡ cảng nhập',	'40`HC'),
('DTHC-40`FR',			N'Phí xếp dỡ cảng nhập', '40`FR'),
('DTHC-FCL',			N'Phí xếp dỡ cảng nhập', 'CONT'),
('DTHC-LCL',			N'Phí xếp dỡ cảng nhập', 'CBM'),
('DTHC-SHPT',			N'Phí xếp dỡ cảng nhập', 'SHIPMENT'),
('DTHC-40`OT',			N'Phí xếp dỡ cảng nhập',	'40`OT'),
(N'DV KIỂM DỊCH',		N'Phí dịch vụ kiểm dịch',	'SHIPMENT'),
(N'DV LÀM HÀNG',		N'Phí dịch vụ làm hàng',	'SHIPMENT'),
('DVHQ',				N'Phí dịch vụ Hải Quan',	'CONT/SET'),
('DVHQ + VCND',			N'Phí dịch vụ hải quan và vận chuyển nội địa', 'SHIPMENT'),
('DVHQ2',				N'Phí dịch vụ hải quan', 'SET'),
('DVKD',				N'Phí dịch vụ kiểm dịch', 'CONT'),
('DVKH',				N'Phí dịch vụ kiểm hóa', 'CONT'),
('DVKH1',				N'Phí dịch vụ kiểm hóa', 'SHIPMENT'),
('EBS',					N'Phụ phí xăng dầu', 'CBM'),
('EMF',					N'Phí quản lý thiết bị', 'CONT'),
('ENS',					N'Phí ENS',	'BỘ'),
('EXPRESS FEE',			N'Phí dịch vụ giao nhận hàng hóa', 'SHIPMENT'),
('EXW',					N'PHÍ EXW',	'SHIPMENT'),
('FACILITY',			N'Phí xử lý hàng hóa',	'SHIPMENT'),
('FUMI',				N'Phí hun trùng',	'SHIPMENT'),
('GRI',					N'Phụ phí cước vận chuyển',	'CBM'),
('HANDLING',			N'Phí handling fee',	'SHIPMENT'),
('HANDLING-CONT',		N'Phí handling fee',	'CONT'),
('HT',					N'Phí Hun Trùng',	'SHIPMENT'),
('IMPORT',				N'Phí Import Tax',	'SET'),
('ISPS',				N'Phí khai báo an ninh',	'SET'),
('KG',					N'Phí đóng kiện gỗ',	'CBM'),
('LABOUR FEE',			N'Phí giao nhận, bốc xếp tại kho',	'CBM'),
('LABOUR FEE-2',		N'Phí giao nhận, bốc xếp tại kho',	'SHIPMENT'),
('LATE',				N'Phí trả chậm',	'SET'),
('LIFT ON-OFF',			N'Phí nâng hạ',	'40`HC'),
('LOCAL CHARGES',		N'Phụ phí địa phương',	'SHIPMENT'),
('LS',					N'Phí chuyển đổi nhiên liệu',	'SHIPMENT'),
('LSS',					N'Phí chuyển đổi nhiên liệu',	'CBM'),
('LSS-20`DC',			N'Phí chuyển đổi nhiên liệu',	'20`DC'),
('LSS-40',				N'Phí chuyển đổi nhiên liệu',	'40'),
('LSS-40`RF',			N'Phí chuyển đổi nhiên liệu',	'40`RF'),
('LSS FEE',				N'Phụ phí giảm thải lưu huỳnh',	'40`HC'),
('LSS FEE 20',			N'Phụ phí giảm thải lưu huỳnh',	'20`DC'),
('LSS-CFS',				N'Phí chuyển đổi nhiên liệu',	'SHIPMENT'),
('OCEAN FREIGHT',		'', ''),
('OTHC-20`DC',			N'Phí xếp dỡ hàng xuất',	'20`DC'),
('OTHC-40',				N'Phí xếp dỡ hàng xuất',	'40'),
('OTHC-FCL',			N'Phí xếp dỡ cảng xuất',	'CONT'),
('OTHC-LCL',			N'Phí xếp dỡ cảng xuất',	'CBM'),
('OVERTIME',			N'Phí dịch vụ ngoài giờ',	'SHIPMENT'),
('PACKING FEE',			N'Phí đóng kiện',	'CBM'),
('PALLET',				N'Phí đóng kiện',	'SHIPMENT'),
(N'PHÍ RÚT RUỘT CONTAINER',	N'Phí rút ruột container',	'CONT'),
('RR',					N'Phụ phí phục hồi giá',	'CBM'),
('SEAL',				N'Phí chì',	'CONT'),
('SEAL FEE',			N'Phí chì',	N'CHIẾC'),
('SURRENDER FEE',		N'Phí điện giao hàng',	'SET'),
('TELEX',				N'Phí điện giao hàng',	'SET'),
('THC FEE',				'', ''),
('TK,TQ',				N'Phí mở tờ khai, thông quan',	'SHIPMENT'),
('TRUCKING FEE',		N'Phí vận tải',	'SHIPMENT'),
('VC',					N'Phí vận chuyển nội địa',	'SET'),
('VCND',				N'Phí vận chuyển nội địa',	'SHIPMENT'),
('VCND HP-BV',			N'Cước vận chuyển nội địa Hải Phòng - Ba Vì',	'CONT'),
('VCND HP-TT',			N'Cước vận chuyển nội địa Hải Phòng - Thạch Thất',	'CONT'),
('VCNOIDIA',			N'Cước vận chuyển nội địa',	'CONT'),
('VCNOIDIA-LCL',		N'Cước vận chuyển nội địa',	'SHIPMENT'),
('VCNOIDIA2',			N'Cước vận chuyển nội địa',	'20`DC'),
('VCNOIDIA3',			N'Cước vận chuyển nội địa',	'40'),
('VCQT',				N'Cước vận chuyển quốc tế',	'CONT'),
('VCQT2',				N'Cước vận chuyển quốc tế',	'CBM/TON'),
('VCQT3',				N'Cước vận chuyển quốc tế',	'20`DC'),
('VCQT4',				N'Cước vận chuyển quốc tế',	'40`DC'),
('VCQT5',				N'Cước vận chuyển quốc tế',	'SHIPMENT'),
('VCQT6',				N'Cước vận chuyển quốc tế',	'40`HC'),
('X RAY',				N'Phí X RAY',	'KGS'),
('XL',					N'Phí xử lý hàng hóa thông thường',	'SHIPMENT');

create table MODE(
	CODE nvarchar(20) not null primary key,
	Note nvarchar(255)
);
insert into MODE(CODE)
values ('AIR/AIR'), ('CFS'), ('CFS/CFS'), ('CW'), ('CY/CY');


create table GOODS_TYPE(
	CODE nvarchar(20) not null primary key,
	GT_name nvarchar(255),
	Note nvarchar(255)
);


insert into GOODS_TYPE(CODE, GT_name, Note) 
values
('AI', 'Air Import', N'hàng không nhập'), 
('AE', 'Air Export', N'hàng không xuất'), 
('FCLI', 'Full Container Load Import', N'hàng nhập nguyên công'), 
('FCLE', 'Full Container Load Export', N'hàng xuất nguyên công'), 
('LCLI', 'Less-than Container Load Import', N'hàng lẻ nhập'), 
('LCLE', 'Less-than Container Load Export', N'hàng lẻ xuất'), 
('LGT', 'Logistics', N'hàng làm thủ tục hải quan');


create table BL_TYPE(
	CODE nvarchar(20) not null primary key,
	BL_name nvarchar(255),
	Note nvarchar(255)
);
insert into BL_TYPE(CODE)
values ('COPY'), ('DRAFT'), ('ORIGINAL'), ('SEWAY BILL'), ('SURRENDERED'), ('TELEX');

create table CURRENCY(
	CODE nvarchar(20) not null primary key,
	Curr_name nvarchar(255),
	Note nvarchar(255)
);
insert into CURRENCY(CODE, Curr_name) 
values 
('CNY', N'Tiền nhân dân tệ'), 
('EUR', N'Tiền chung châu âu'),
('GBP', N'Bảng Anh'),
('JPY', N'Tiền Yên'),
('KRW', N'Tiền hàn quốc'),
('SGD', N'Tiền singafore'),
('USD', N'Tiền đô Mỹ'),
('VND', N'Tiền việt nam');

create table SOURSE(
	CODE nvarchar(20) not null primary key,
	Sour_name nvarchar(255),
	Note nvarchar(255)
);
insert into SOURSE(CODE) 
values ('FREEHAND'), ('NOMI');

create table UNIT(
	CODE nvarchar(20) not null primary key,
	Unit_name nvarchar(255),
	Note nvarchar(255)
);

insert into UNIT(CODE) 
values ('20`DC'), ('20`GP'), ('20`OT'), ('20`RF'), ('40`GP'), ('40`HC'), ('40`OT'), ('40`FR'), ('CBM'), ('OT'), ('SHIPMENT');


create table CPORT(
	CODE nvarchar(20) not null primary key,
	PORT_NAME nvarchar(255),
);


create table tbl_HSCODE(
	ID int primary key not null identity(1,1),
	HS_CODE nvarchar(20),
	
	Mo_ta_hang_hoaV nvarchar(max),

	Mo_ta_hang_hoaE nvarchar(max),
	
	Don_vi_tinh nvarchar(50),

	Thue_NK_TT float default 0,
	Thue_NK_UD float default 0,
	
	Thue_VAT nvarchar(100),
	ACFTA float default 0,
	ATIGA float default 0,
	AJCEP float default 0,
	VJEPA float default 0,
	AKFTA float default 0,
	AANZFTA float default 0,
	AIFTA float default 0,
	VKFTA float default 0,
	VCFTA float default 0,
	VN_EAEU float default 0,
	CPTPP float default 0,
	AHKFTA float default 0,
	VNCU float default 0,
	EVFTA float default 0,
	UKVFTA float default 0,
	VN_LAO float default 0,
	RCEPT_A float default 0,
	RCEPT_B float default 0,
	RCEPT_C float default 0,
	RCEPT_D float default 0,
	RCEPT_E float default 0,
	RCEPT_F float default 0,
	TTDB float default 0,
	XK float default 0,
	XKCPTPP float default 0,
	XKEV float default 0,
	XKUKV float default 0,
	Thue_BVMT nvarchar(100),
	Chinh_sach_hang_hoa nvarchar(1000),

	Giam_VAT nvarchar(50),
	Chi_tiet_giam_VAT nvarchar(500),

	Mo_ta_khong_dau nvarchar(max),
	Ghi_chu nvarchar(max),
	Ghi_chu_khong_dau nvarchar(max),
);

CREATE TABLE Quotations (
    QuotationID nvarchar(50) not null primary key,
	Qsatus nvarchar(255),

	Staff_name nvarchar(255),
	contact nvarchar(100),
	Qdate datetime,
	

	CusTo nvarchar(255),
	CusContact nvarchar(255),
	Valid datetime,

    Term NVARCHAR(255),
    Vol NVARCHAR(255),
	Commodity NVARCHAR(255),

    POL NVARCHAR(255),
    ADDs NVARCHAR(255),
    POD NVARCHAR(255),
    
	
);


CREATE TABLE Quotations_Charges (
    ChargeID int primary key not null identity(1,1),
    QuotationID nvarchar(50) FOREIGN KEY REFERENCES Quotations(QuotationID),
    
    ChargeName NVARCHAR(255),

	Quantity float default 1,
	Unit nvarchar(255),

	rate float default 0,
    
    Currency NVARCHAR(10),
    Notes NVARCHAR(255),
);




