main = do
    radius <- getLine
    let radiusDouble = read radius :: Double
    let area = pi * radiusDouble * radiusDouble
    let areaStr = show area
    putStrLn(areaStr)