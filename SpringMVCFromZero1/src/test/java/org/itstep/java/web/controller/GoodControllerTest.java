/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package org.itstep.java.web.controller;

import java.util.ArrayList;
import java.util.List;
import org.itstep.java.web.model.Category;
import org.itstep.java.web.model.Good;
import org.itstep.java.web.service.GoodService;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import org.springframework.ui.Model;
import org.springframework.validation.support.BindingAwareModelMap;
import org.springframework.ui.ModelMap;

/**
 *
 * @author Valya
 */
public class GoodControllerTest {
    
   GoodService srv;   
//   ModelMap model;
    
    
    public GoodControllerTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        
     // model = new ModelMap();
        srv = new GoodService() {  
            
            @Override
            public List<Good> all() {
                return new ArrayList <> (); //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public List<Good> all(Integer categoryId) {
               return new ArrayList <> ();//To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public List<Good> getList(Integer id) {
                return new ArrayList <> (); //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public List<Category> getCategoryList() {
                return new ArrayList <> (); //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public Good find(Integer id) {
                return new Good () ; //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public Category findCategory(Integer id) {
               
                return new Category (); //To change body of generated methods, choose Tools | Templates.
            }
            
        } ;
    }
        
    
    
    @After
    public void tearDown() {
    }

    /**
     * Test of all method, of class GoodController.
     */
    @Test
    public void testAll_Model() {
        System.out.println("all");
        Model model = new BindingAwareModelMap();
        GoodController instance = new GoodController(srv);
        instance.all(model);      
        String expResult = "all";
        String result = instance.all(model);
        assertEquals(expResult, result);
//        // TODO review the generated test code and remove the default call to fail.
////        fail("The test case is a prototype.");
    }
//
//    /**
//     * Test of all method, of class GoodController.
//     */
    @Test
    public void testAll_Integer_Model() {
        System.out.println("all");
        Integer id = 2;
        Model model = new BindingAwareModelMap();
       GoodController instance = new GoodController(srv);
        instance.all(model);
        String expResult = "all";
        String result = instance.all(id, model);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
//        fail("The test case is a prototype.");
    }
    
}
