import { render, screen } from '@testing-library/react';
import ProductCard from '../../components/ProductCard';
import UserRole from '../../utils/UserRole';

describe('ProductCard component', () => {
  const mockOnDelete = jest.fn();
  const mockOnEdit = jest.fn();
  const mockOnAddToCart = jest.fn();

  it('should display product details correctly', () => {
    render(<ProductCard 
      name="Product A" 
      description="Description of Product A" 
      value="20.00" 
      userRole={UserRole.User} 
      imageUrl="https://via.placeholder.com/150" 
      onDelete={mockOnDelete} 
      onEdit={mockOnEdit} 
      onAddToCart={mockOnAddToCart} 
      isUserLoggedIn={true} 
    />);

    expect(screen.getByText('Product A')).toBeInTheDocument();
    expect(screen.getByText('Description of Product A')).toBeInTheDocument();
    expect(screen.getByText('R$ 20.00')).toBeInTheDocument();
    expect(screen.getByText('Adicionar ao Carrinho')).toBeInTheDocument();
  });
});
