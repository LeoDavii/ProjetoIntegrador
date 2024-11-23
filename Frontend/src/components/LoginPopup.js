import React, { useState } from 'react';
import './styles/LoginPopup.css';

const LoginPopup = ({ onClose, onLoginSuccess }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleLogin = async (e) => {
        e.preventDefault();
        setError('');

        try {
            const response = await fetch('https://localhost:44321/api/user', {
                method: 'PATCH',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email: username, password: password }),
            });

            if (response.ok) {
                const data = await response.json();
                alert('Login realizado com sucesso!');
                onLoginSuccess(data.name, data.token, data.role);
                onClose();
            } else {
                setError('Usuário ou senha inválidos');
            }
        } catch (err) {
            setError('Erro ao conectar ao servidor');
        }
    };

    return (
        <div className="popup-overlay">
            <div className="popup-content">
                <button className="close-btn" onClick={onClose}>&times;</button>
                <form onSubmit={handleLogin}>
                    <div className="form-group">
                        <label htmlFor="username">Email</label>
                        <input
                            type="text"
                            id="username"
                            name="username"
                            value={username}
                            onChange={(e) => setUsername(e.target.value)}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Senha</label>
                        <input
                            type="password"
                            id="password"
                            name="password"
                            value={password}
                            onChange={(e) => setPassword(e.target.value)}
                            required
                        />
                    </div>
                    {error && <p className="error-message">{error}</p>}
                    <button type="submit" className="login-btn">Entrar</button>
                </form>
            </div>
        </div>
    );
};

export default LoginPopup;
