checkSeason :: Int -> String
checkSeason a
    | a == 12 || a == 1 || a == 2 = "Зима"
    | a == 3 || a == 4 || a == 5 = "Пролет"
    | a == 6 || a == 7 || a == 8 = "Лято"
    | a == 9 || a == 10 || a == 11 = "Есен"
    | otherwise = "Невалиден месец."

main = do
    putStrLn "Въведете число:"
    numStr <- getLine
    let num = read numStr :: Int
    putStrLn (checkSeason num)