main :: IO ()
main = do
    putStrLn "Въведete число:"
    input1 <- getLine
    let a = read input1 :: Int
    let result =
          if a `mod` 2 == 0
          then "Четно"
              else "Нечетно"
    putStrLn result