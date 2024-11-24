import { render, fireEvent, screen, waitFor } from '@testing-library/react';
import LoginPopup from '../../components/LoginPopup';

describe('LoginPopup component', () => {
  const mockOnClose = jest.fn();
  const mockOnLoginSuccess = jest.fn();

  it('should display error message when login fails', async () => {
    global.fetch = jest.fn().mockResolvedValue({
      ok: false,
      json: jest.fn().mockResolvedValue({}),
    });

    render(<LoginPopup onClose={mockOnClose} onLoginSuccess={mockOnLoginSuccess} />);

    fireEvent.change(screen.getByLabelText(/email/i), { target: { value: 'test@test.com' } });
    fireEvent.change(screen.getByLabelText(/senha/i), { target: { value: 'wrongpassword' } });
    fireEvent.click(screen.getByText(/entrar/i));

    await screen.findByText('Usuário ou senha inválidos');
  });

  it('should call onLoginSuccess when login succeeds', async () => {
    global.fetch = jest.fn().mockResolvedValue({
      ok: true,
      json: jest.fn().mockResolvedValue({ name: 'John Doe', token: 'token123', role: 'user' }),
    });

    render(<LoginPopup onClose={mockOnClose} onLoginSuccess={mockOnLoginSuccess} />);

    fireEvent.change(screen.getByLabelText(/email/i), { target: { value: 'test@test.com' } });
    fireEvent.change(screen.getByLabelText(/senha/i), { target: { value: 'correctpassword' } });
    fireEvent.click(screen.getByText(/entrar/i));

    await waitFor(() => expect(mockOnLoginSuccess).toHaveBeenCalledWith('John Doe', 'token123', 'user'));
  });

  it('should close popup when close button is clicked', () => {
    render(<LoginPopup onClose={mockOnClose} onLoginSuccess={mockOnLoginSuccess} />);

    fireEvent.click(screen.getByRole('button', { name: /×/ }));

    expect(mockOnClose).toHaveBeenCalled();
  });

  it('should display error message when there is a server connection error', async () => {
    global.fetch = jest.fn().mockRejectedValue(new Error('Server Error'));

    render(<LoginPopup onClose={mockOnClose} onLoginSuccess={mockOnLoginSuccess} />);

    fireEvent.change(screen.getByLabelText(/email/i), { target: { value: 'test@test.com' } });
    fireEvent.change(screen.getByLabelText(/senha/i), { target: { value: 'correctpassword' } });
    fireEvent.click(screen.getByText(/entrar/i));

    await screen.findByText('Erro ao conectar ao servidor');
  });
});