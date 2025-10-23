grade :: Int -> String
grade a
  | a >= 90 && a <= 100 = "Отличен"
  | a >= 75 && a <= 89  = "Много добър"
  | a >= 50 && a <= 74  = "Добър"
  | a >= 0 && a < 50    = "Слаб"
  | otherwise           = "Невалидни данни за вход. Опитайте отново."

main = do
    putStrLn "Въведете число:"
    input1 <- getLine
    let a = read input1 :: Int
    putStrLn (grade a)