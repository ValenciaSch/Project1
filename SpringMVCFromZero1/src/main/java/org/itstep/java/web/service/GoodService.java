package org.itstep.java.web.service;

import java.util.List;
import org.itstep.java.web.model.Good;
import org.itstep.java.web.model.Category;
public interface GoodService {
    List<Good> all();
    List<Good> all(Integer categoryId);
    
    
    public List<Good> getList(Integer id);
    public List<Category> getCategoryList();
    public Good find(Integer id);
    public Category findCategory(Integer id);
}
