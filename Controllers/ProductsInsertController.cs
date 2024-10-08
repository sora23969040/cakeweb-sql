using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_cake.Data;
using web_cake.Models; // 引入模型命名空间

public class ProductsInsertController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsInsertController(ApplicationDbContext context)
    {
        _context = context;
    }

    // 显示上传页面
    public IActionResult Index()
    {
        return View();
    }

    // 处理表单提交
    [HttpPost]
    public async Task<IActionResult> Insert(Products products)
    {
        // 保存到数据库
        _context.Database.ExecuteSqlRaw("CALL usp_EditProduct(@p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7)", "Add", 0, products.ProductName, products.Category, products.Price, products.StockQuantity, products.Description, 1);
        return RedirectToAction("Index", "Products"); // 或者返回一个成功的消息

    }
}