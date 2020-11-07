import java.util.Date;
/**
 * 
 *
 * @author Zak Smith
 * @version 11/10/2020
 */
public class Ticket
{
    // Attributes
    
    private String destination;
    
    private int price;
    
    private Date issueDateTime;
    
    /**
     * Constructor for objects of class Ticket setting the
     * desitnation and price.
     */
    public Ticket(String destination, int price)
    {
        this.destination = destination;
        this.price = price;

        issueDateTime = new Date();
    }
    
    public int getPrice()
    {
        return price;
    
    }
    
    public String getDestination()
    {
        return destination;
    }
    
    /**
     * Prints the date, destination and price of a ticket
     */
    public void print()
    {
        System.out.println("Ticket " + destination + 
            " Price : " + price + 
            " Issued " + issueDateTime);
    }
    

}