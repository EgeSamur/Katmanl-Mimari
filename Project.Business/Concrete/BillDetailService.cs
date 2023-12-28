﻿using Azure.Core;
using Project.Business.Abstract;
using Project.Common.Paging;
using Project.Common.Utilities.Results;
using Project.DataAccess.Abstract;
using Project.DataAccess.Concrete;
using Project.DTO;
using Project.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Concrete;

public class BillDetailService : IBillDetailService
{
    private readonly IBillDetailsRepository _billDetailRepository;
    private readonly ICategoryRepository _categoryRepository;

    public BillDetailService(IBillDetailsRepository billDetailRepository , ICategoryRepository categoryRepository)
    {
        _billDetailRepository = billDetailRepository;
        _categoryRepository = categoryRepository;
    }
    public IDataResult<BillDetails> CreateBillDetail(BillDetaiDto billDetaiDto)
    {
        var category = _categoryRepository.Get(c => c.Name == billDetaiDto.CategoryName);
        if (category != null) 
        {
            var billDateDateTime = DateTime.ParseExact(billDetaiDto.BillDate, "dd.MM.yyyy", null);
            var longTotal = decimal.Parse(billDetaiDto.Total);
            var longTotalKdv = decimal.Parse(billDetaiDto.TotalKdv);
            var billDetail = new BillDetails
            {
                Id = new Guid(),
                BillDate = billDateDateTime,
                Total = longTotal,
                TotalKdv = longTotalKdv,
                BillNo = billDetaiDto.BillNo,
                VKN = billDetaiDto.VKN,
                Category = category,
                CategoryId = category.Id
            };

            _billDetailRepository.Add(billDetail);
            // TO DO --> Oluşturduğum BillDetaili da Category içersindeki BillDetails'e eklemeliyim ????????????
            return new SuccessDataResult<BillDetails>(billDetail, "BillDetails Created.");
            
        }

        return new ErrorDataResult<BillDetails>("Something Went Wrong..");
        
    }

    public IResult DeleteBillDetail(Guid id)
    {
        var billDetail = _billDetailRepository.Get(bd => bd.Id == id);
        if (billDetail != null)
        {
            _billDetailRepository.Delete(billDetail);
            return new SuccessResult("Bill Detail Deleted.");
        }
        return new ErrorResult("Something Went Wrong..");
    }

    //public IResult FilterBills(FilterBillRequest request)
    //{// Filtreleme ifadelerini oluştur

    //    ////Sadece Kategori İdye göre
    //    //if(request.CategoryId != null && request.BillDateStart == null && request.BillDateEnd == null && request.TotalKDVMax == 0 && request.TotalKDVMin == 0 && request.TotalMax == 0 && request.TotalMin == 0)
    //    //{

    //    //}
    //    ////Sadece Date Göre
    //    //if (request.CategoryId == null && request.BillDateStart != null && request.BillDateEnd != null && request.TotalKDVMax == 0 && request.TotalMax == 0 && request.TotalMax == 0 && request.TotalMin == 0)
    //    //{ 

    //    //}
    //    ////Sadece Kdv'ye göre Göre
    //    //if (request.CategoryId == null && request.BillDateStart == null && request.BillDateEnd == null && request.TotalKDVMax >= 0 && request.TotalMax > 0 && request.TotalMax == 0 && request.TotalMin == 0)
    //    //{

    //    //}

    //    //if (request.CategoryId == null && request.BillDateStart == null && request.BillDateEnd == null && request.TotalKDVMax == 0 && request.TotalMax == 0 && request.TotalMax > 0 && request.TotalMin == 0)
    //    //{

    //    //}








    //    //if (request.BillDateStart != null && request.BillDateEnd != null &&request.TotalKDVMax == 0 && request.TotalMax == 0 && request.TotalMin ==0 && request.TotalMin == 0)
    //    //{
    //    //    Expression<Func<BillDetails, bool>> predicate = i =>
    //    //           (request.CategoryId == null || i.CategoryId == request.CategoryId) ||
    //    //           (request.BillDateStart == null || i.BillDate >= request.BillDateStart) &&
    //    //           (request.BillDateEnd == null || i.BillDate <= request.BillDateEnd);
    //    //    var results = _billDetailRepository.GetList(predicate);
    //    //    if (results.Count > 0)
    //    //    {
    //    //        return new SuccessDataResult<IPaginate<BillDetails>>(results);

    //    //    }
    //    //}

    //    #region Düzeltilecek
    //    //else if (request.TotalKDVMax == 0 && request.TotalKDVMin == 0)
    //    //{
    //    //    Expression<Func<BillDetails, bool>> predicate = i =>
    //    //  (request.CategoryId == null || i.CategoryId == request.CategoryId) ||
    //    //  (request.BillDateStart == null || i.BillDate >= request.BillDateStart) &&
    //    //  (request.BillDateEnd == null || i.BillDate <= request.BillDateEnd) ||
    //    //  (request.TotalMin == 0 || i.Total >= request.TotalMin) &&
    //    //  (request.TotalMax == 0 || i.Total <= request.TotalMax);

    //    //    var results = _billDetailRepository.GetList(predicate);
    //    //    if (results.Count > 0)
    //    //    {
    //    //        return new SuccessDataResult<IPaginate<BillDetails>>(results);

    //    //    }
    //    //}
    //    //else if (request.TotalMax == 0 && request.TotalMin == 0)
    //    //{
    //    //    Expression<Func<BillDetails, bool>> predicate = i =>
    //    //  (request.CategoryId == null || i.CategoryId == request.CategoryId) ||
    //    //  (request.BillDateStart == null || i.BillDate >= request.BillDateStart) &&
    //    //  (request.BillDateEnd == null || i.BillDate <= request.BillDateEnd) ||
    //    //  (request.TotalKDVMin == 0 || i.TotalKdv >= request.TotalKDVMin) &&
    //    //  (request.TotalKDVMax == 0 || i.TotalKdv <= request.TotalKDVMax);

    //    //    var results = _billDetailRepository.GetList(predicate);
    //    //    if (results.Count > 0)
    //    //    {
    //    //        return new SuccessDataResult<IPaginate<BillDetails>>(results);

    //    //    }
    //    //}

    //    //else
    //    //{
    //    //    Expression<Func<BillDetails, bool>> predicate = i =>
    //    //  (request.CategoryId == null || i.CategoryId == request.CategoryId) &&
    //    //  (request.BillDateStart == null || i.BillDate >= request.BillDateStart) &&
    //    //  (request.BillDateEnd == null || i.BillDate <= request.BillDateEnd) &&
    //    //  (request.TotalKDVMin == 0 || i.TotalKdv >= request.TotalKDVMin) &&
    //    //  (request.TotalKDVMax == 0 || i.TotalKdv <= request.TotalKDVMax) && 
    //    //  (request.TotalMin == 0 || i.Total >= request.TotalMin) &&
    //    //  (request.TotalMax == 0 || i.Total <= request.TotalMax);

    //    //    var results = _billDetailRepository.GetList(predicate);
    //    //    if (results.Count > 0)
    //    //    {
    //    //        return new SuccessDataResult<IPaginate<BillDetails>>(results);

    //    //    }
    //    //}
    //    #endregion




    //    return new ErrorResult("Someting Went Wrong");

    //}
    public IResult GetBillDetailsBills(SizeIndex sizeIndex)
    {
        var result = _billDetailRepository.GetList(index:sizeIndex.Index, size:sizeIndex.Size);
        if(result != null)
        {
            return new SuccessDataResult<IPaginate<BillDetails>>(result);

        }
        return new ErrorResult("Something went wrong.");

    }
    public IResult FilterBills(FilterBillRequest request, int index = 0, int size = 10)
    {
        var category = _categoryRepository.Get(c=>c.Id == request.CategoryId);
        
        
        if(category != null)
        {
            // Filtreleme ifadelerini oluştur
            Expression<Func<BillDetails, bool>> predicate = i =>
               (request.CategoryId == null || i.CategoryId == request.CategoryId) &&
               (request.BillDateStart == null || i.BillDate >= request.BillDateStart) &&
               (request.BillDateEnd == null || i.BillDate <= request.BillDateEnd) &&
               (request.TotalKDVMin == 0 || i.TotalKdv >= request.TotalKDVMin) &&
               (request.TotalKDVMax == 0 || i.TotalKdv <= request.TotalKDVMax) &&
               (request.TotalMin == 0 || i.Total >= request.TotalMin) &&
               (request.TotalMax == 0 || i.Total <= request.TotalMax);

            var result = _billDetailRepository.GetList(predicate, index: index, size: size);
            return new SuccessDataResult<IPaginate<BillDetails>>(result);

        }


        return new ErrorResult("Something Went Wrong.");
        //var result = _billDetailRepository.GetList(predicate, index: index, size: size);
        //return new SuccessDataResult<IPaginate<BillDetails>>(result);
    }



    public IResult GetTotalForAMount(ForTotal fortTotal)
    {
        decimal total = 0;
        decimal totalKdv = 0;
        var category = _categoryRepository.Get(i=>i.Id == fortTotal.CategoryId);
        if(category != null)
        {
            Expression<Func<BillDetails, bool>> predicate = i =>
            (fortTotal.CategoryId == null || i.CategoryId == fortTotal.CategoryId) &&
        (fortTotal.BillDateStart == null || i.BillDate >= fortTotal.BillDateStart) &&
        (fortTotal.BillDateEnd == null || i.BillDate <= fortTotal.BillDateEnd);
            var billList = _billDetailRepository.GetList(predicate, size: 999999999);
            if (billList.Count > 0)
            {

                foreach (var item in billList.Items)
                {
                    total += item.Total;
                    totalKdv += item.TotalKdv;

                }

                var totalDto = new TotalDto
                {
                    Total = total,
                    TotalKdv = totalKdv
                };

                return new SuccessDataResult<TotalDto>(totalDto);
            }
        }
        

       
       
        return new ErrorResult("Something went wrong.");


    }

    //public IResult UpdateBillDetail(BillDetaiDto billDetaiDto)
    //{
    //    var billDetail = _billDetailRepository.Get
    //    _billDetailRepository.Update()
    //}
}
