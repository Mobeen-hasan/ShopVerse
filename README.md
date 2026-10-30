# ShopVerse

A multi-role e-commerce desktop application built with C# WinForms and SQL Server.

## Features

- **Customer, Seller, and Admin roles**, each with their own login and home screen
- Product browsing with dynamic filtering by category, price range, rating, and seller
- Shopping cart with stock validation and cart creation on first use
- Checkout flow that creates orders and order-detail records
- Wishlist with duplicate-item prevention
- Seller-side order management and sales reporting

## Tech stack

- C# / .NET (WinForms)
- SQL Server (ADO.NET, SqlConnection/SqlCommand, parameterized queries)

## Notes

This was built as a university database systems project. Known limitations: passwords are not hashed, and some image paths are hardcoded to a local machine, both are things I'd address in a production version.
