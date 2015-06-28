
package org.itstep.java.web.model;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

@Entity
@Table(name = "tb_user")
public class User implements Serializable, UserDetails {
     static GrantedAuthority auth = new GrantedAuthority() {
        @Override
        public String getAuthority() {
            return "ROLE_USER";
        }
    };
    
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;
      @Column(name = "NameUser")
    private String name;
        @Column(name = "Email")
    private String email;
          @Column(name = "Password")
    private String password;          
    private boolean banned;

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public User(String name, String email) {
        this.name = name;
        this.email = email;
    }
    
    public User(String name) {
        this.name = name;
    }
    
    public User() {
        
    }
    
    public boolean isBanned() {
        return banned;
    }

    void setBanned(boolean banned) {
        this.banned = banned;
    }
    
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        List<GrantedAuthority> list = new ArrayList<>();
        list.add(auth);
        return list;
    }

    @Override
    public String getUsername() {
        return email;
    }

    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }
    
}
