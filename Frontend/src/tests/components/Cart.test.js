import React from 'react';
import { render, screen, fireEvent } from '@testing-library/react';
import '@testing-library/jest-dom';
import { useCart } from '../../utils/CartContext';
import Cart from '../../components/Cart';

jest.mock('../../utils/CartContext', () => ({
  useCart: jest.fn(),
}));

describe('Cart Component', () => {
  let mockCartContext;
  let onCloseMock;

  beforeEach(() => {
    mockCartContext = {
      cart: [
        { id: 1, name: 'Cupcake', value: 10, quantity: 2, imageUrl: '/image1.jpg' },
        { id: 2, name: 'Cookie', value: 5, quantity: 1, imageUrl: '/image2.jpg' },
      ],
      removeFromCart: jest.fn(),
      updateQuantity: jest.fn(),
      clearCart: jest.fn(),
      isOpen: true,
      setIsOpen: jest.fn(),
    };

    onCloseMock = jest.fn();
    useCart.mockReturnValue(mockCartContext);
  });

  afterEach(() => {
    jest.clearAllMocks();
  });

  test('renders the cart title', () => {
    render(<Cart onClose={onCloseMock} />);
    const titleElement = screen.getByText(/carrinho de compras/i);
    expect(titleElement).toBeInTheDocument();
  });

  test('renders all items in the cart', () => {
    render(<Cart onClose={onCloseMock} />);
    const cartItems = screen.getAllByRole('img');
    expect(cartItems).toHaveLength(mockCartContext.cart.length);
  });

  test('displays total price correctly', () => {
    render(<Cart onClose={onCloseMock} />);
    const totalPriceElement = screen.getByText(/total: r\$25\.00/i);
    expect(totalPriceElement).toBeInTheDocument();
  });

  test('removes an item from the cart when clicking the remove button', () => {
    render(<Cart onClose={onCloseMock} />);
    const removeButtons = screen.getAllByRole('button', { name: '' });
    fireEvent.click(removeButtons[0]);
    expect(mockCartContext.removeFromCart).toHaveBeenCalledWith(1);
  });

  test('updates item quantity when increment button is clicked', () => {
    render(<Cart onClose={onCloseMock} />);
    const incrementButtons = screen.getAllByText('+');
    fireEvent.click(incrementButtons[0]);
    expect(mockCartContext.updateQuantity).toHaveBeenCalledWith(1, 3);
  });

  test('displays checkout modal on completing checkout', () => {
    render(<Cart onClose={onCloseMock} />);
    const checkoutButton = screen.getByText(/finalizar compra/i);
    fireEvent.click(checkoutButton);
    const modalTitle = screen.getByText(/pedido efetuado com sucesso/i);
    expect(modalTitle).toBeInTheDocument();
  });

  test('closes modal when close button is clicked', () => {
    render(<Cart onClose={onCloseMock} />);
    const checkoutButton = screen.getByText(/finalizar compra/i);
    fireEvent.click(checkoutButton);
    const closeModalButton = screen.getByText(/fechar/i);
    fireEvent.click(closeModalButton);
    expect(mockCartContext.setIsOpen).toHaveBeenCalledWith(false);
  });

  test('calls onClose when the cart close button is clicked', () => {
    render(<Cart onClose={onCloseMock} />);
    const closeButton = screen.getByText('X');
    fireEvent.click(closeButton);
    expect(onCloseMock).toHaveBeenCalled();
    expect(mockCartContext.setIsOpen).toHaveBeenCalledWith(false);
  });

  test('displays empty cart message when cart is empty', () => {
    useCart.mockReturnValue({ ...mockCartContext, cart: [] });
    render(<Cart onClose={onCloseMock} />);
    const emptyMessage = screen.getByText(/seu carrinho está vazio/i);
    expect(emptyMessage).toBeInTheDocument();
  });
});
