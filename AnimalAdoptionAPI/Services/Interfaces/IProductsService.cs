using AnimalAdoptionAPI.Models;


namespace AnimalAdoptionAPI.Interfaces
{
    public interface IProductsService
    {
        List<Products> GetAllProducts();
        Products GetProductById(int id);
        Products AddProduct(AddProductsDto addProduct);
        Products UpdateProductById(int id, UpdateProductsDto updateProduct);
        bool DeleteProductById(int id);
    }
}
