import React, { createContext, useState, useContext } from 'react';

const CartContext = createContext();

export const useCart = () => useContext(CartContext);

export const CartProvider = ({ children }) => {
    const [cart, setCart] = useState([]); // Estado para os itens no carrinho
    const [isOpen, setIsOpen] = useState(false); // Estado para controlar o carrinho

    const addToCart = (product) => {
        setCart((prevCart) => {
            const existingProduct = prevCart.find(item => item.id === product.id);
            if (existingProduct) {
                return prevCart.map(item =>
                    item.id === product.id
                        ? { ...item, quantity: item.quantity + 1 }
                        : item
                );
            }
            return [...prevCart, { ...product, quantity: 1 }];
        });
        setIsOpen(true); // Abre o carrinho automaticamente
    };

    const removeFromCart = (productId) => {
        setCart((prevCart) => prevCart.filter(item => item.id !== productId));
    };

    const updateQuantity = (productId, quantity) => {
        setCart((prevCart) => 
            prevCart.map(item =>
                item.id === productId
                    ? { ...item, quantity }
                    : item
            )
        );
    };

    const clearCart = () => {
        setCart([]); // Limpa o carrinho
    };

    return (
        <CartContext.Provider value={{
            cart, 
            addToCart, 
            removeFromCart, 
            updateQuantity, 
            clearCart, 
            isOpen, 
            setIsOpen
        }}>
            {children}
        </CartContext.Provider>
    );
};
