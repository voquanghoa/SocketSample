import socket
import json
import sys
    
SERVER_DOMAIN = 'localhost'
SERVER_PORT = 6721

def send_ma_yte(ma):
    data = {
        "type": "MaYTe",
        "content": content
    }

    json_data = json.dumps(data)

    with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as s:
        s.connect((SERVER_DOMAIN, SERVER_PORT))
        s.sendall(json_data.encode('utf-8'))
        
        print(f"Sent: {json_data}")
        
        s.close()


if __name__ == "__main__":
    if len(sys.argv) < 1:
        print("Usage: python Main.py <content>")
        sys.exit(1)

    content = sys.argv[1]
    
    send_ma_yte(content)


