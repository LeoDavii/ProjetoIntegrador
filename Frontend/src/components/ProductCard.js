import React, { useState } from 'react';
import './styles/ProductCard.css';
import { FaTrash, FaEdit } from 'react-icons/fa';
import UserRole from '../utils/UserRole';
import { useUser } from '../utils/UserContext';

const ProductCard = ({ name, description, value, imageUrl, onDelete, onEdit, onAddToCart, isUserLoggedIn }) => {
  const [editableValue, setEditableValue] = useState(value);
  const { userRole } = useUser();

  const handleValueChange = (e) => {
    const value = e.target.value;
    if (/^\d*\.?\d*$/.test(value)) { 
      setEditableValue(value);
    }
  };

  return (
    <div className="product-card">
      <img
        src={imageUrl || "https://via.placeholder.com/150"}
        alt={name}
        className="product-image"
      />
      <h3>{name}</h3>
      <p>{description}</p>
      {userRole == UserRole.Manager ? (
        <>
          <input
            type="text"
            value={editableValue}
            onChange={handleValueChange}
            className="value-input"
          />
          <div className="manager-buttons">
            <button onClick={onDelete} className="icon-button">
              <FaTrash />
            </button>
            <button onClick={onEdit} className="icon-button">
              <FaEdit />
            </button>
          </div>
        </>
      ) : (
        <>
          <span className="value">R$ {value}</span>
          <button 
            className="add-to-cart" 
            onClick={() => isUserLoggedIn && onAddToCart({ name, description, value, imageUrl })} 
            disabled={!isUserLoggedIn} 
            title={!isUserLoggedIn ? "Faça login para adicionar ao carrinho" : ""}
          >
            Adicionar ao Carrinho
          </button>
        </>
      )}
    </div>
  );
};


export default ProductCard;
