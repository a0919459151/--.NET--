-- 檢查並刪除已存在的臨時表格
IF OBJECT_ID('tempdb..#TempPreviousPrices') IS NOT NULL
    DROP TABLE #TempPreviousPrices;

-- 查看 FundNav 結果
-- SELECT * FROM FundNav f
-- ORDER BY f.[Symbol], f.[Date];

SELECT 
    f.[Date],
    f.[Symbol],
    f.[Price],
    LAG(f.[Date]) OVER (PARTITION BY f.[Symbol] ORDER BY f.[Date]) AS PreviousDate,
    LAG(f.[Price]) OVER (PARTITION BY f.[Symbol] ORDER BY f.[Date]) AS PreviousPrice
INTO #TempPreviousPrices
FROM FundNav f;

-- 查看 #TempPreviousPrices 結果
-- SELECT * FROM #TempPreviousPrices;


SELECT 
    p.[Date],
    p.[Symbol],
    (p.[Price] / p.PreviousPrice - 1) AS ReturnRate
FROM #TempPreviousPrices p
WHERE p.PreviousPrice IS NOT NULL
ORDER BY p.[Symbol], p.[Date];

DROP TABLE #TempPreviousPrices;

