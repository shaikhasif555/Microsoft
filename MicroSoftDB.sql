USE [MicroSoftDB]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 06/29/2019 14:57:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DocNo] [int] NULL,
	[Date] [date] NULL,
	[JobNo] [int] NULL,
	[Customer] [nvarchar](50) NULL,
	[QuotNo] [int] NULL,
	[EstNo] [int] NULL,
	[EnqNo] [int] NULL,
	[QuotationAmt] [decimal](18, 2) NULL,
	[InvoiceAmt] [decimal](18, 2) NULL,
	[MainJob] [varchar](50) NULL,
	[PaymentTerm] [varchar](50) NULL,
	[Remarks] [nvarchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_Invoice]    Script Date: 06/29/2019 14:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_Invoice]

(
@Id int,
@DocNo int,
@Date datetime,
@JobNo varchar(50),
@Customer varchar(50),
@QuotNo int,
@EstNo int,
@EnqNo int,
@QuotationAmt int,
@InvoiceAmt decimal,
@MainJob varchar(50),
@PaymentTerm varchar(50),
@Remarks varchar(50),
@flag nvarchar(50)
)
as
begin

if @flag='Insert'
begin
Insert into Invoice (DocNo,[Date],JobNo,Customer,QuotNo,EstNo,EnqNo,QuotationAmt,InvoiceAmt,MainJob,PaymentTerm,Remarks)
values (@DocNo,@Date,@JobNo,@Customer,@QuotNo,@EstNo,@EnqNo,@QuotationAmt,@InvoiceAmt,@MainJob,@PaymentTerm,@Remarks)
Select SCOPE_IDENTITY() as 'ID'
end
if @flag='Update'
begin
Update Invoice set 
DocNo=@DocNo,
[Date]=@Date,
JobNo=@JobNo,
Customer=@Customer,
QuotNo=@QuotNo,
EstNo=@EstNo,
EnqNo=@EnqNo,
QuotationAmt=@QuotationAmt,
InvoiceAmt=@InvoiceAmt,
MainJob=@MainJob,
PaymentTerm=@PaymentTerm,
Remarks=@Remarks 
where Id=@Id
select @Id as 'ID'

end
if @flag='Delete'
begin
Delete from Invoice where Id=@Id
select @Id as 'ID'
end

end
GO
/****** Object:  StoredProcedure [dbo].[get_Invoice]    Script Date: 06/29/2019 14:57:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[get_Invoice]
(
@Id int
)
as

begin
if @Id>0
begin
select * from Invoice where Id=@Id
end
else
begin
select * from Invoice  order by Id desc
end
end
GO
