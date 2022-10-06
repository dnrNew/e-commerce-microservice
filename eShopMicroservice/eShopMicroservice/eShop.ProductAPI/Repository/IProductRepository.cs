﻿using eShop.ProductAPI.Data.ValueObjects;

namespace eShop.ProductAPI.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductVO>> GetAll();
        Task<ProductVO> GetById(long id);
        Task<ProductVO> Create(ProductVO vo);
        Task<ProductVO> Update(ProductVO vo);
        Task<bool> Delete(long id);
    }
}
