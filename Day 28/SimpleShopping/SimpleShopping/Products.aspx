<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Products" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShopNow - Products</title>
    <style>
        body { font-family: Arial; margin: 0; background-color: #f5f5f5; }
        .header { background-color: #4CAF50; color: white; padding: 15px; text-align: center; }
        .container { width: 90%; margin: auto; padding: 20px; }
        .product-grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(250px, 1fr)); gap: 20px; margin-top: 20px; }
        .product-card { background: white; border-radius: 8px; box-shadow: 0 2px 5px rgba(0,0,0,0.1); padding: 15px; text-align: center; }
        .product-image { height: 150px; background-color: #f0f0f0; border-radius: 5px; margin-bottom: 15px; display: flex; align-items: center; justify-content: center; color: #888; }
        .product-name { font-weight: bold; font-size: 18px; margin-bottom: 10px; }
        .product-price { color: #4CAF50; font-size: 20px; margin-bottom: 15px; }
        .btn-add { background-color: #4CAF50; color: white; border: none; padding: 10px 15px; border-radius: 4px; cursor: pointer; }
        .cart-summary { position: fixed; bottom: 0; right: 0; background: white; padding: 15px; border-radius: 5px 0 0 0; box-shadow: 0 -2px 10px rgba(0,0,0,0.1); }
        .btn-checkout { background-color: #2196F3; color: white; padding: 10px 15px; border: none; border-radius: 4px; cursor: pointer; margin-top: 10px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>ShopNow Products</h1>
            <p>Welcome, <asp:Label ID="lblUsername" runat="server" Text="Guest"></asp:Label>!</p>
        </div>
        <div class="container">
            <div class="product-grid">
                <div class="product-card">
                    <div class="product-image">T-Shirt Image</div>
                    <div class="product-name">Comfort T-Shirt</div>
                    <div class="product-price">$19.99</div>
                    <asp:Button ID="btnAddTShirt" runat="server" Text="Add to Cart" CssClass="btn-add" OnClick="btnAddTShirt_Click" />
                </div>
                <div class="product-card">
                    <div class="product-image">Jeans Image</div>
                    <div class="product-name">Blue Denim Jeans</div>
                    <div class="product-price">$39.99</div>
                    <asp:Button ID="btnAddJeans" runat="server" Text="Add to Cart" CssClass="btn-add" OnClick="btnAddJeans_Click" />
                </div>
                <div class="product-card">
                    <div class="product-image">Shoes Image</div>
                    <div class="product-name">Running Shoes</div>
                    <div class="product-price">$59.99</div>
                    <asp:Button ID="btnAddShoes" runat="server" Text="Add to Cart" CssClass="btn-add" OnClick="btnAddShoes_Click" />
                </div>
                <div class="product-card">
                    <div class="product-image">Backpack Image</div>
                    <div class="product-name">Travel Backpack</div>
                    <div class="product-price">$49.99</div>
                    <asp:Button ID="btnAddBackpack" runat="server" Text="Add to Cart" CssClass="btn-add" OnClick="btnAddBackpack_Click" />
                </div>
            </div>
        </div>
        <div class="cart-summary">
            <h3>Cart Summary</h3>
            <asp:Label ID="lblCartCount" runat="server" Text="Items in cart: 0"></asp:Label><br />
            <asp:Label ID="lblTotalAmount" runat="server" Text="Total: $0.00"></asp:Label><br />
            <asp:Button ID="btnViewCart" runat="server" Text="View Cart & Checkout" CssClass="btn-checkout" OnClick="btnViewCart_Click" />
        </div>
    </form>
</body>
</html>
