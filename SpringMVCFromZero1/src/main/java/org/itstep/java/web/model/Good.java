package org.itstep.java.web.model;

import java.io.Serializable;
import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.ManyToOne;
import javax.persistence.MapKeyColumn;
import javax.persistence.Table;
import org.springframework.transaction.annotation.Transactional;

@Entity
@Table(name = "tb_clothing")

//@Transactional
public class Good implements Serializable {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    Integer Id;
    
//   @Column(name = "Category_id")
//    Integer categoryId;

   
   
    @Column(name = "Name")
    String name;  
    @Column(name = "Discription")
    String discription;
     @Column(name = "Image")
    String image;
     @Column(name = "Price")
    Float price;
     
     
    @ManyToOne(cascade = CascadeType.ALL)
    @MapKeyColumn(name = "Category_id")
    Category category;

    public Category getCategory() {
        return category;
    }

    public void setCategory(Category category) {
        this.category = category;
    }
     
    
public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    public Float getPrice() {
        return price;
    }

    public void setPrice(Float price) {
        this.price = price;
    }
    
     public String getDiscription() {
        return discription;
    }

    public void setDiscription(String discription) {
        this.discription = discription;
    }

    public String getImage() {
        return image;
    }

    public void setImage(String image) {
        this.image = image;
    }
   
   
}
