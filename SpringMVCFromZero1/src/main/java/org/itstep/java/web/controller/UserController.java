package org.itstep.java.web.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.SessionAttributes;
import org.itstep.java.web.service.UserService;
import org.itstep.java.web.model.User;

@Controller
@RequestMapping("/user")
@SessionAttributes("current")
public class UserController {
   @Autowired
    UserService userService;
    
    public UserController(UserService srv) {
        this.userService = srv;
    }
   
    @RequestMapping(value = "show", method = RequestMethod.GET)
    public String user(
            UsernamePasswordAuthenticationToken currentUser,
            @RequestParam(value = "id",required = true, defaultValue = "1")
            Integer id,
            Model model) {
        User u = userService.find(id);
        User current = (User) currentUser.getPrincipal();
        model.addAttribute("user", u);
        model.addAttribute("current", current);
        model.addAttribute("title", current.getName());
        return "user";
    }
    
    @RequestMapping(value = "/login", method = RequestMethod.GET)
    public String login(ModelMap model) {
        
        return "login";
    }  
     @RequestMapping(value = "/logout", method = RequestMethod.GET)
    public String logout(ModelMap model) {
        
        return "logout";
    }  
}
