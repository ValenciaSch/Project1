package org.itstep.java.web.controller;

import org.itstep.java.web.service.GoodService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("/goods")
@Transactional
public class GoodController {
    
    @Autowired
    GoodService goodService;
    
    
    @RequestMapping(method = RequestMethod.GET)
    public String all(  Model model) {
//        model.addAttribute("goods", goodService.all());
        return "all";
    }
    
    
    @RequestMapping(value = "/all/{id}", method = RequestMethod.GET)
    public String all(
            @PathVariable(value = "id")
            Integer id,
            Model model) {
        model.addAttribute("goods", goodService.all(id));
        return "all";
    }
    
}
