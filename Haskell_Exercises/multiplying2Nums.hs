main = do
    num1 <- getLine
    num2 <- getLine
    let number1 = read num1 :: Int;
    let number2 = read num2 :: Int;
    let sum = number1 * number2;
    let sumStr = show sum;
    putStrLn(sumStr);