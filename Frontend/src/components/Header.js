import React, { useState, useEffect, useRef } from 'react';
import { FaShoppingCart, FaUser } from 'react-icons/fa';
import LoginPopup from './LoginPopup.js';
import { useUser } from '../utils/UserContext';
import Cart from './Cart.js';
import './styles/Header.css';
import UserRole from '../utils/UserRole.js';
import { useCart } from '../utils/CartContext.js';

const Header = () => {
    const [showDropdown, setShowDropdown] = useState(false);
    const [showLoginPopup, setShowLoginPopup] = useState(false);
    const { isOpen, setIsOpen } = useCart();
    const dropdownRef = useRef(null);

    const { setUserRole, userRole, userName, setUserName, setUserToken } = useUser();

    const toggleDropdown = () => {
        setShowDropdown(!showDropdown);
    };

    const openLoginPopup = () => {
        setShowLoginPopup(true);
        setShowDropdown(false);
    };

    const closeLoginPopup = () => {
        setShowLoginPopup(false);
    };

    const handleLoginSuccess = (name, token, role) => {
        setUserName(name); 
        setUserRole(role);
        setUserToken(token);
        setShowLoginPopup(false);
    };

    const handleLogout = () => {
        setUserName(null);
        setUserRole(null);
        setUserToken(null);
        setShowDropdown(false); 
    };

    const toggleCart = () => {
        setIsOpen(!isOpen);
    };

    useEffect(() => {
        const handleClickOutside = (event) => {
            if (dropdownRef.current && !dropdownRef.current.contains(event.target)) {
                setShowDropdown(false);
            }
        };

        document.addEventListener("mousedown", handleClickOutside);

        return () => {
            document.removeEventListener("mousedown", handleClickOutside);
        };
    }, []);

    return (
        <header className="header">
            <h1 className="logo">Cupcake Store</h1>
            <nav className="nav">
                <a href="/">Produtos</a>
                <a href="about">Sobre Nós</a>
                <a href="contact">Contato</a>
            </nav>
            <div className="actions">
                {userName ? (
                    <div className="user-info">
                        <span>{userName}</span>
                        <div className="login-dropdown" ref={dropdownRef}>
                            <button className="icon-button login" onClick={toggleDropdown} title="Sair">
                                <FaUser />
                            </button>
                            {showDropdown && (
                                <div className="dropdown-menu">
                                    <button onClick={handleLogout}>Sair</button>
                                </div>
                            )}
                        </div>
                    </div>
                ) : (
                    <div className="login-dropdown" ref={dropdownRef}>
                        <button className="icon-button login" onClick={toggleDropdown} title="Login">
                            <FaUser />
                        </button>
                        {showDropdown && (
                            <div className="dropdown-menu">
                                <button onClick={openLoginPopup}>Login</button>
                            </div>
                        )}
                    </div>
                )}
                
                {userName && (
                    <button 
                        className={`icon-button cart ${userRole === UserRole.Manager ? 'disabled' : ''}`} 
                        onClick={toggleCart} 
                        title="Carrinho" 
                        disabled={userRole === 'manager'}>
                        <FaShoppingCart />
                    </button>
                )}
            </div>
            {showLoginPopup && <LoginPopup onClose={closeLoginPopup} onLoginSuccess={handleLoginSuccess} />}
            {isOpen && <Cart onClose={toggleCart} />}
        </header>
    );
};

export default Header;
