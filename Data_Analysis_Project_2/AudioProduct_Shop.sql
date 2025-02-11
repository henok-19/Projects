with cte as(
select 
a.product,
a.Category,
a.Brand,
a.Description,
a.Sale_Price,
a.Cost_Price,
a.Image_url,

b.Date,
b.Customer_Type,
b.Discount_Band,
b.Units_Sold,

(Sale_Price * Units_Sold) as revenue,
(Cost_Price * Units_Sold) as total_cost,
format(date, 'MMMM') as month,
format(date, 'yyyy') as year
from Product_data a
join product_sales b
on a.Product_ID = b.Product)

select 
*,
(1-discount*1.0/100)*revenue as discount_revenue
from cte a
join discount_data b
on a.Discount_Band = b.Discount_Band and a.month = b.Month



--UPDATE product_sales
--SET Date = CONVERT(DATETIME2, FORMAT(CONVERT(DATE, Date, 103), 'dd/MM/yyyy'))
--WHERE ISDATE(CONVERT(VARCHAR, Date, 120)) = 1

