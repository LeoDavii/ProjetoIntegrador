import React, { useState, useEffect } from 'react';
import ProductCard from './ProductCard';
import { FaPlus, FaExclamationCircle } from 'react-icons/fa';
import './styles/Products.css';
import { useUser } from '../utils/UserContext';
import UserRole from '../utils/UserRole';
import { useCart } from '../utils/CartContext';

const Products = () => {
  const { userRole } = useUser();
  const isUserLoggedIn = userRole !== null;
  const { addToCart } = useCart();
  const [products, setProducts] = useState([]);
  const [showModal, setShowModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [productForm, setProductForm] = useState({
    name: '',
    description: '',
    value: '0.00',
    imageUrl: '',
  });
  const [errors, setErrors] = useState({});
  const { setIsOpen } = useCart();

  const fetchProducts = async () => {
    try {
      const response = await fetch('https://localhost:44321/api/product');
      if (response.ok) {
        const data = await response.json();
        setProducts(data);
      } else {
        console.error('Erro ao buscar os produtos');
      }
    } catch (error) {
      console.error('Erro de rede:', error);
    }
  };

  useEffect(() => {
    fetchProducts();
  }, []);

  const validateForm = () => {
    const newErrors = {};
    if (!productForm.name.trim()) newErrors.name = 'O nome é obrigatório.';
    if (!productForm.description.trim()) newErrors.description = 'A descrição é obrigatória.';
    if (!productForm.value || isNaN(parseFloat(productForm.value)) || parseFloat(productForm.value) <= 0)
      newErrors.value = 'O valor deve ser maior que zero.';
    if (!productForm.imageUrl.trim()) newErrors.imageUrl = 'A URL da imagem é obrigatória.';
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleInsert = () => {
    setSelectedProduct(null);
    setProductForm({ name: '', description: '', value: '0.00', imageUrl: '' });
    setErrors({});
    setShowModal(true);
  };

  const handleAddToCart = (product) => {
    addToCart(product); 
    setIsOpen(true); 
  };

  const handleDeleteConfirmation = (product) => {
    setSelectedProduct(product);
    setShowDeleteModal(true);
  };

  const handleDelete = async () => {
    try {
      const response = await fetch(`https://localhost:44321/api/product/${selectedProduct.id}`, {
        method: 'DELETE',
      });

      if (response.ok) {
        setProducts((prevProducts) => prevProducts.filter((product) => product.id !== selectedProduct.id));
        setShowDeleteModal(false);
      } else {
        console.error('Erro ao excluir o produto.');
      }
    } catch (error) {
      console.error('Erro de rede:', error);
    }
  };

  const handleEdit = (product) => {
    setSelectedProduct(product);
    setProductForm({
      name: product.name,
      description: product.description,
      value: product.value,
      imageUrl: product.imageUrl,
    });
    setErrors({});
    setShowModal(true);
  };

  const handleFormChange = (e) => {
    const { name, value } = e.target;
    setProductForm({ ...productForm, [name]: value });
    setErrors({ ...errors, [name]: null });
  };

  const handleSubmit = async () => {
    if (!validateForm()) return;

    const formData = {
      Id: selectedProduct ? selectedProduct.id : null,
      Value: parseFloat(productForm.value),
      Name: productForm.name,
      Description: productForm.description,
      ImageUrl: productForm.imageUrl,
    };

    try {
      const response = await fetch('https://localhost:44321/api/product', {
        method: 'PUT',
        body: JSON.stringify(formData),
        headers: { 'Content-Type': 'application/json' },
      });

      if (response.ok) {
        setShowModal(false);
        await fetchProducts();
      } else {
        console.error('Erro ao enviar os dados.');
      }
    } catch (error) {
      console.error('Erro de rede:', error);
    }
  };

  return (
    <section className="products">
      <div className="product-list">
        {products.map((product) => (
          <ProductCard
            key={product.id}
            name={product.name}
            description={product.description}
            value={product.value}
            imageUrl={product.imageUrl}
            onDelete={() => handleDeleteConfirmation(product)}
            onEdit={() => handleEdit(product)}
            onAddToCart={() => handleAddToCart(product)} 
            isUserLoggedIn={isUserLoggedIn}
          />
        ))}
        {userRole === UserRole.Manager && (
          <div className="add-product-card" onClick={handleInsert}>
            <FaPlus size={32} />
          </div>
        )}
      </div>
      {showDeleteModal && (
        <div className="modal">
          <div className="modal-content">
            <h3>Confirmação de Exclusão</h3>
            <p>Tem certeza que deseja excluir o produto "{selectedProduct?.name}"?</p>
            <div className="button-container">
              <button className="cancelButton" onClick={() => setShowDeleteModal(false)}>Cancelar</button>
              <button className="confirmButton" onClick={handleDelete}>Confirmar</button>
            </div>
          </div>
        </div>
      )}
      {showModal && (
        <div className="modal">
          <div className="modal-content">
            <h3>{selectedProduct ? 'Editar Produto' : 'Adicionar Produto'}</h3>
            <input
              type="text"
              name="name"
              value={productForm.name}
              onChange={handleFormChange}
              placeholder="Nome do Produto"
              className={errors.name ? 'input-error' : ''}
            />
            {errors.name && (
              <div className="error-message">
                <FaExclamationCircle />
                {errors.name}
              </div>
            )}

            <textarea
              name="description"
              value={productForm.description}
              onChange={handleFormChange}
              placeholder="Descrição do Produto"
              className={errors.description ? 'input-error' : ''}
            />
            {errors.description && (
              <div className="error-message">
                <FaExclamationCircle />
                {errors.description}
              </div>
            )}

            <input
              type="text"
              name="imageUrl"
              value={productForm.imageUrl}
              onChange={handleFormChange}
              placeholder="URL da Imagem"
              className={errors.imageUrl ? 'input-error' : ''}
            />
            {errors.imageUrl && (
              <div className="error-message">
                <FaExclamationCircle />
                {errors.imageUrl}
              </div>
            )}

            <input
              type="number"
              name="value"
              value={productForm.value}
              onChange={handleFormChange}
              placeholder="Valor"
              className={errors.value ? 'input-error' : ''}
            />
            {errors.value && (
              <div className="error-message">
                <FaExclamationCircle />
                {errors.value}
              </div>
            )}

            <div className="button-container">
              <button className="cancelButton" onClick={() => setShowModal(false)}>Cancelar</button>
              <button className="confirmButton" onClick={handleSubmit}>Salvar</button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default Products;
