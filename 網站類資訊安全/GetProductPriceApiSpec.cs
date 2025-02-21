/// <summary>
/// 請求參數
/// </summary>
public class GetProductPriceRequestDto
{
    /// <summary>
    /// 商品 Id
    /// </summary>

    public string ProductId { get; set; }
}

/// <summary>
/// 回應參數
/// </summary>
public class GetProductPriceResponseDto
{
    /// <summary>
    /// 是否為會員
    /// </summary>
    public bool IsMember { get; set; }

    /// <summary>
    /// 商品 Id
    /// </summary>
    public string ProductId { get; set; }

    /// <summary>
    /// 原價
    /// </summary> 
    public decimal Price { get; set; }

    /// <summary>
    /// 折扣金額
    /// </summary>
    public decimal DiscountPrice { get; set; }
}