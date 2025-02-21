-- 使用該資料庫
USE CUBETest;
GO

-- 創建 FundNav 資料表
CREATE TABLE FundNav (
    [Date] DATE NOT NULL, 
    [Symbol] CHAR(8) NOT NULL, 
    [Price] REAL NOT NULL,
    PRIMARY KEY ([Date], [Symbol])
);
GO

-- 插入測試資料
INSERT INTO FundNav 
    ([Date], [Symbol], [Price]) 
VALUES 
    ('2024-02-17', '2330', 1001.5),  -- 跳日
    ('2024-02-19', '2330', 1000.5),
    ('2024-02-20', '2330', 1001.0),
    ('2024-02-21', '2330', 1002.8),
    ('2024-02-19', '1101', 30.1),
    ('2024-02-21', '1101', 31.2),
    ('2024-02-23', '1101', 30.2);  -- 跳日
GO
