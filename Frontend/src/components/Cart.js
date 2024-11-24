import React, { useEffect, useState } from 'react';
import { useCart } from '../utils/CartContext';
import { FaTrash } from 'react-icons/fa';
import './styles/Cart.css';

const Cart = ({ onClose }) => {
    const { cart, removeFromCart, updateQuantity, clearCart, isOpen, setIsOpen } = useCart();
    const [orderSuccess, setOrderSuccess] = useState(false);
    const [showCart, setShowCart] = useState(true)

    useEffect(() => {
        if (isOpen) {
        }
    }, [isOpen]);

    const handleRemove = (id) => {
        removeFromCart(id);
    };

    const handleQuantityChange = (id, quantity) => {
        if (quantity <= 0) return;
        updateQuantity(id, quantity);
    };

    const totalPrice = cart.reduce((total, item) => total + item.value * item.quantity, 0);

    const handleCheckout = () => {
        setOrderSuccess(true);
        clearCart();
        setShowCart(false);
    };

    const handleCloseButton = () => {
        setOrderSuccess(false);
        setIsOpen(false);
    };

    return (
        <div className={`cart-overlay ${isOpen ? 'open' : ''} ${!showCart ? 'checkout' : '' }`}>
            <div className={`cart-container ${!showCart ? 'close' : '' }`}>
                <div className="cart-header">
                    <h2>Carrinho de Compras</h2>
                    <button onClick={() => { onClose(); setIsOpen(false); }} className="close-button">X</button>
                </div>
                <div className="cart-items">
                    {cart.length === 0 ? (
                        <p className="empty-message">Seu carrinho está vazio</p>
                    ) : (
                        cart.map((item) => (
                            <div key={item.id} className="cart-item">
                                <img src={item.imageUrl} alt={item.name} className="cart-item-image" />
                                <div className="cart-item-details">
                                    <span className="product-name">{item.name}</span>
                                    <div className="quantity-controls">
                                        <span className="product-value">R$ {item.value}</span>
                                        <button onClick={() => handleQuantityChange(item.id, item.quantity - 1)}>-</button>
                                        <span>{item.quantity}</span>
                                        <button onClick={() => handleQuantityChange(item.id, item.quantity + 1)}>+</button>
                                        <button onClick={() => handleRemove(item.id)} className="remove-button">
                                            <FaTrash />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        ))
                    )}
                </div>
                {cart.length > 0 && (
                    <div className="cart-footer">
                        <p>Total: R${totalPrice.toFixed(2)}</p>
                        <button onClick={handleCheckout} className="checkout-button">Finalizar Compra</button>
                    </div>
                )}
            </div>
            {orderSuccess && (
                <div className="modal-overlay">
                    <div className="modal-container">
                        <h3>Pedido Efetuado com Sucesso!</h3>
                        <p>Obrigado por comprar conosco. Seu pedido foi recebido com sucesso.</p>
                        <button onClick={handleCloseButton} className="close-modal-button">Fechar</button>
                    </div>
                </div>
            )}
        </div>
    );
};

export default Cart;
