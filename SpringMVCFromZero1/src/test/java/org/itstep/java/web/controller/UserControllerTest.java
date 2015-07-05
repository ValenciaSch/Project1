/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package org.itstep.java.web.controller;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import org.itstep.java.web.model.User;
import org.itstep.java.web.service.GoodService;
import org.itstep.java.web.service.UserService;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.validation.support.BindingAwareModelMap;

/**
 *
 * @author Valya
 */
public class UserControllerTest {
    UserService usrv; 
 
    public UserControllerTest() {
    }
    
    @BeforeClass
    public static void setUpClass() {
    }
    
    @AfterClass
    public static void tearDownClass() {
    }
    
    @Before
    public void setUp() {
        
      usrv=  new UserService() {

            @Override
            public User find(Integer id) {
                return new User (); //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public List<User> findAll() throws SQLException {
                return new ArrayList <>(); //To change body of generated methods, choose Tools | Templates.
            }

            @Override
            public int save(User u) {
                return 25;
            }
        };
    }
    
    @After
    public void tearDown() {
    }

    /**
     * Test of user method, of class UserController.
     */
    @Test
    public void testUser() {
        System.out.println("user");
        UsernamePasswordAuthenticationToken currentUser = null;        
        Integer id = 3;
        Model model = new BindingAwareModelMap();
        UserController instance = new UserController(usrv);
        instance.user(currentUser, id, model); 
        String expResult = "user";
        String result = instance.user(currentUser, id, model);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
//        fail("The test case is a prototype.");
    }
//
//    /**
//     * Test of login method, of class UserController.
//     */
    @Test
    public void testLogin() {
        System.out.println("login");
        ModelMap model = new BindingAwareModelMap();
        UserController instance = new UserController(usrv);
        instance.login(model);  
        String expResult = "login";
        String result = instance.login(model);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
//        fail("The test case is a prototype.");
    }

    /**
     * Test of logout method, of class UserController.
     */
    @Test
    public void testLogout() {
        System.out.println("logout");
        ModelMap model = new BindingAwareModelMap();
       UserController instance = new UserController(usrv);
        instance.logout(model); 
        String expResult = "logout";
        String result = instance.logout(model);
        assertEquals(expResult, result);
        // TODO review the generated test code and remove the default call to fail.
//        fail("The test case is a prototype.");
    }
    
}
