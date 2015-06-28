package org.itstep.java.web.service;

import java.util.List;
import javax.transaction.Transactional;
import org.hibernate.Query;
import org.hibernate.SessionFactory;
import org.itstep.java.web.model.Good;
import org.itstep.java.web.model.Category;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.stereotype.Service;

@Service(value = "userService")
@Transactional
public class GoodServiceImpl implements GoodService {

    @Autowired
    @Qualifier(value = "sessionFactory")
    SessionFactory sf;
    
    @Override
    public List<Good> all() {
        return sf.getCurrentSession().createQuery("from Good").list();
    }

    @Override
    public List<Good> all(Integer categoryId) {
        Query q = sf.getCurrentSession().createQuery("from Good g where g.category.id=:cat");
        q.setInteger("cat", categoryId);
        System.out.println(q.getQueryString());
        return q.list();
    }
    
    
     @Override
    public List<Good> getList(Integer id) {
        Query q = sf.getCurrentSession().createQuery("from Good g where g.category.id = :catId");
        q.setInteger("catId", id);
        return q.list();
    }

    @Override
    public List<Category> getCategoryList() {
        Query q = sf.getCurrentSession().createQuery("from Category");
        return q.list();
    }

    @Override
    public Good find(Integer id) {
        return (Good) sf.getCurrentSession().get(Good.class, id);
    }

    @Override
    public Category findCategory(Integer id) {
        return (Category) sf.getCurrentSession().get(Category.class, id);
    }
    
    
    
}
