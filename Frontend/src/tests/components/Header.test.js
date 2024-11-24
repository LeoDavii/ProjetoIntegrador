import { render, fireEvent, screen } from '@testing-library/react';
import Header from '../../components/Header';
import { UserContext } from '../../utils/UserContext';
import { CartContext } from '../../utils/CartContext';

describe('Header component', () => {
  const renderWithProviders = (userContextValue, cartContextValue) => {
    return render(
      <UserContext.Provider value={userContextValue}>
        <CartContext.Provider value={cartContextValue}>
          <Header />
        </CartContext.Provider>
      </UserContext.Provider>
    );
  };

  it('should display login button when user is not logged in', () => {
    const userContextValue = { userName: null };
    const cartContextValue = { isOpen: false, setIsOpen: jest.fn() };
    
    renderWithProviders(userContextValue, cartContextValue);
    
    const loginButton = screen.getByTitle('Login');
    fireEvent.click(loginButton);
    
    expect(screen.getByText('Login')).toBeInTheDocument();
  });

  it('should display user name and logout option when user is logged in', () => {
    const userContextValue = { userName: 'John Doe', userRole: null };
    const cartContextValue = { isOpen: false, setIsOpen: jest.fn() };
    
    renderWithProviders(userContextValue, cartContextValue);
    
    const userName = screen.getByText('John Doe');
    expect(userName).toBeInTheDocument();
  });

  it('should toggle cart visibility when cart button is clicked', () => {
    const userContextValue = { userName: 'John Doe' };
    const cartContextValue = { isOpen: false, setIsOpen: jest.fn() };
    
    renderWithProviders(userContextValue, cartContextValue);
    
    const cartButton = screen.getByTitle('Carrinho');
    fireEvent.click(cartButton);
    
    expect(cartContextValue.setIsOpen).toHaveBeenCalledWith(true);
  });

  it('should open login popup when login button is clicked', () => {
    const userContextValue = { userName: null };
    const cartContextValue = { isOpen: false, setIsOpen: jest.fn() };
    
    renderWithProviders(userContextValue, cartContextValue);
    
    const loginButton = screen.getByTitle('Login');
    fireEvent.click(loginButton);
    
    expect(screen.getByText('Login')).toBeInTheDocument();
  });

  it('should display disabled cart button when user role is manager', () => {
    const userContextValue = { userName: 'John Doe', userRole: '1' };
    const cartContextValue = { isOpen: false, setIsOpen: jest.fn() };
    
    renderWithProviders(userContextValue, cartContextValue);
    
    const cartButton = screen.getByTitle('Carrinho');
    expect(cartButton).toBeDisabled();
  });
});