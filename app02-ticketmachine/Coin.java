
/**
 * 
 *
 * @author Zak Smith
 * @version 11/10/2020
 */

//Creates a constant class
 public enum Coin
    {
        P10 (10),
        P20 (20),
        P100 (100),
        P200 (200);

        private final int value;

        private Coin(int value)
        {
            this.value = value;
        }

        public int getValue()
        {
            return value;
        }
     }