import java.util.ArrayList;
import java.util.*;

/**
 * Manage the stock in a business.
 * The stock is described by zero or more Products.
 * 
 * @author Zak Smith 
 * @version 1.0, 01/12/20
 */
public class StockManager
{
    // A list of the products.
    private ArrayList<Product> stock;
    
    List <Product> listStock = new ArrayList<Product>();

    /**
     * Initialise the stock manager.
     */
    public StockManager()
    {
        stock = new ArrayList<>();
    }

    /**
     * Add a product to the list.
     * @param item The item to be added.
     */
    public boolean addProduct(Product item)
    {
        if(findProduct(item.getID()) != null)
        {
            System.out.println("This product has the same ID as another product!");
            return false;
        }
        else
        {
            stock.add(item);
            System.out.println("\n You have added " + item);
            return true;
        }
    }
    
    /**
     * Receive a delivery of a particular product.
     * Increase the quantity of the product by the given amount.
     * @param id The ID of the product.
     * @param amount The amount to increase the quantity by.
     */
    public void delivery(int id, int amount)
    {
        //this method is for delivering the stock of the products
        Product product = findProduct(id);
        if(product != null)
        {
            product.increaseQuantity(amount);
            System.out.println("Product Delivered: " + product);
        }
        else
        {
            System.out.println("Product ID " + id + " was not found");
        }
        
    }
    
    /**
     * Replacing the name of the products
     */
    public void newProductName(int id, String newProduct)
    {
        // this method will be to change the name of a desired product
        Product product = findProduct(id);
        if(product != null)
        {
            product.changeName(newProduct);
        }
        else
        {
            System.out.println("This Product DOES NOT Exist");
        }
    }
    
    /**
     * Removing product from stock list
     */
    public void removeProduct(int id)
    {
        Product product = findProduct(id);
        if(product !=null)
        {
            stock.remove(product);
        }
        else
        {
            System.out.println("This Product HAS NOT been found!!");
        }
    }
    
    /**
     * Method for selling an item of your choice
     */
        public void sellProduct(int id)
    {
        Product product = findProduct(id);
        
        if(product != null) 
        {
            printDetails(id);
            product.sellOne();
            printDetails(id);
        }
    }
    
     /**
      *  Gathering the information about the items which
      *  have a low stock level
      */
     public void printLowInStock()
    {
        listStock.clear();
        
        for (Product product : stock)
        {
            if (product.checkLow() == true)
            {
                listStock.add(product);
            }
        }
        System.out.println("The Following Products Have Low Stock:~");
        printListStock();
    }
    
    /**
     * printing listStock
     */
    public void printListStock()
    {
        listStock.forEach(product ->
        {
            System.out.println(product);
        });
    }
    
    /**
     * Show details of the given product. If the product is found,
     * the name and stock quantity will be shown.
     * @param id The ID of the product to look for.
     */
    public void printDetails(int id)
    {
        Product product = findProduct(id);
        
        if(product != null) 
        {
            System.out.println(product.toString());
        }
    }
    
    /**
     * Try to find a product in the stock with the given id.
     * @return The identified product, or null if there is none
     *         with a matching ID.
     */
    public Product findProduct(int id)
    {
        for(Product product : stock)
        {
            if(product.getID() == id)
            {
                return product;
            }
        }
        return null;
    }
    
    /**
     * Searching for a product by their name
     */
    public void searchProductKeyword(String keyword)
    {
        listStock.clear();
        for(Product product : stock)
        {
            if(product.getName().contains(keyword))
            {
                listStock.add(product);
            }
        }
        printListStock();
    }
    
    /**
     * Locate a product with the given ID, and return how
     * many of this item are in stock. If the ID does not
     * match any product, return zero.
     * @param id The ID of the product.
     * @return The quantity of the given product in stock.
     */
    public int numberInStock(int id)
    {
        return 0;
    }

    /**
     * Print details of all the products.
     */
    public void printAllProducts()
    {
        for(Product product : stock)
        {
            System.out.println(product);
        }
    }
}