import { render, screen } from '@testing-library/react';
import Products from '../../components/Products';
import { UserContext } from '../../utils/UserContext';
import { CartContext } from '../../utils/CartContext';

describe('Products', () => {
  const mockAddToCart = jest.fn();
  
  const renderWithContext = (userRole, isUserLoggedIn = true) => {
    render(
      <UserContext.Provider value={{ userRole }}>
        <CartContext.Provider value={{ addToCart: mockAddToCart }}>
          <Products />
        </CartContext.Provider>
      </UserContext.Provider>
    );
  };

  it('should render a list of products when fetched', async () => {
    const mockProducts = [
      { id: 1, name: 'Product 1', description: 'Description 1', value: 100, imageUrl: '' },
      { id: 2, name: 'Product 2', description: 'Description 2', value: 200, imageUrl: '' },
    ];

    global.fetch = jest.fn().mockResolvedValueOnce({
      ok: true,
      json: async () => mockProducts,
    });

    renderWithContext('Customer');
    
    await screen.findByText('Product 1');
    await screen.findByText('Product 2');
    
    // Then
    expect(screen.getByText('Product 1')).toBeInTheDocument();
    expect(screen.getByText('Product 2')).toBeInTheDocument();
  });
});
