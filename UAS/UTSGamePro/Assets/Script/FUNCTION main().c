FUNCTION main()  
  INT a = 2 + 4 * 6 - 8 / 4
  INT b = a++
  SWITCH (b)
    CASE 7 :
      print("A")
      BREAK
    CASE 25 :
      print("B")
      BREAK
    DEFAULT :
      print("C")
      BREAK 
  END SWITCH
END FUNCTION