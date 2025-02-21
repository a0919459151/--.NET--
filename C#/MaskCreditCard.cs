public class Sol
{
    public static string MaskCreditCard(string cardNumber)
    {
        // 檢查是否為有效數字字串
        if (string.IsNullOrWhiteSpace(cardNumber) || !Regex.IsMatch(cardNumber, @"^\d+$"))
        {
            return "輸入無效";
        }

        int length = cardNumber.Length;
        if (length <= 4)
        {
            return cardNumber; // 如果長度小於等於 4，則直接回傳
        }

        // 取出末四碼
        string lastFour = cardNumber.Substring(length - 4);

        // 計算要隱藏的部分長度
        int maskLength = length - 4;
        string masked = new string('*', maskLength);

        // 將隱碼與最後四碼組合，並保持 4 位分隔格式
        string formattedMask = FormatMaskedNumber(masked, lastFour);

        return formattedMask;
    }

    private static string FormatMaskedNumber(string masked, string lastFour)
    {
        string fullMasked = masked + lastFour; // 將隱碼與最後四碼合併
        int length = fullMasked.Length;
        string result = "";

        // 以 4 位數為一組插入 `-`
        for (int i = 0; i < length; i += 4)
        {
            if (i > 0) result += "-";
            result += fullMasked.Substring(i, Math.Min(4, length - i));
        }

        return result;
    }
}
