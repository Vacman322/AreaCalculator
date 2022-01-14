select Product.Title, Category.[Name]
from Product
left join ProductCategory on (Product.ID = ProductCategory.IDProduct)
left join Category on (Category.ID = ProductCategory.IDCategory)