import { render, screen } from '@testing-library/react';
import ProductCard from '../../components/ProductCard';
import UserRole from '../../utils/UserRole';
import { UserContext } from '../../utils/UserContext';

describe('ProductCard component', () => {
  const mockOnDelete = jest.fn();
  const mockOnEdit = jest.fn();
  const mockOnAddToCart = jest.fn();

  it('should display product details correctly', () => {
    const userContextValue = { userName: 'John Doe', userRole: null };

    render(
      <UserContext.Provider value={userContextValue}>
        <ProductCard 
          name="Product A" 
          description="Description of Product A" 
          value="20.00" 
          userRole={UserRole.User} 
          imageUrl="https://via.placeholder.com/150" 
          onDelete={mockOnDelete} 
          onEdit={mockOnEdit} 
          onAddToCart={mockOnAddToCart} 
          isUserLoggedIn={true} 
        />
      </UserContext.Provider>
    );

    expect(screen.getByText('Product A')).toBeInTheDocument();
    expect(screen.getByText('Description of Product A')).toBeInTheDocument();
    expect(screen.getByText('R$ 20.00')).toBeInTheDocument();
    expect(screen.getByText('Adicionar ao Carrinho')).toBeInTheDocument();
  });
});
