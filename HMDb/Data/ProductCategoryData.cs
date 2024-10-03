﻿using HMDb.DbAccess;
using HMDb.Models;

namespace HMDb.Data;

public class ProductCategoryData : IProductCategoryData
{
    private readonly ISqlDataAccess _sql;

    public ProductCategoryData(ISqlDataAccess sql)
    {
        _sql = sql;
    }

    public async Task<List<ProductCategory>> GetProductCategories()
    {
        string sql = "SELECT Id, Name FROM ProduktKategori";

        IEnumerable<ProductCategory> productCategories = await _sql.LoadData<ProductCategory, dynamic>(sql, new { });

        return productCategories.ToList();
    }

    //public async Task<List<Member>> GetMembers(int brfId)
    //{
    //    string sql = "SELECT id, brf_id, personalid, name, email, phone FROM member WHERE brf_id = @brfId";

    //    IEnumerable<Member> members = await _sql.LoadData<Member, dynamic>(sql, new { brfId });

    //    return members.ToList();
    //}

    public async Task CreateProductCategory(ProductCategory productCategory)
    {
        string sql = "INSERT INTO ProduktKategori (Name) VALUES (@Name)";

        await _sql.SaveData(sql, new { productCategory.Name });
    }

    //public async Task UpdateMember(Member member)
    //{
    //    string sql = "UPDATE member" +
    //                 " SET personalid = @personalId, name = @name, email = @email, phone = @phone" +
    //                 " WHERE id = @id";

    //    await _sql.SaveData(sql, new { member.PersonalId, member.Name, member.Email, member.Phone, member.Id });
    //}

    public async Task DeleteProductCategory(int productCategoryId)
    {
        string sql = "DELETE FROM ProduktKategori WHERE Id = @productCategoryId";

        await _sql.SaveData(sql, new { productCategoryId });
    }
}
