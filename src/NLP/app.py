from flask import Flask, request, jsonify
import spacy

app = Flask(__name__)

nlp = spacy.load("pt_core_news_lg")

@app.route('/processar_mensagem', methods=['POST'])
def processar_mensagem():
    try:
        data = request.get_json()

        if 'mensagem' not in data:
            return jsonify({'error': 'A chave "mensagem" não está presente no JSON'}), 400

        mensagem = data['mensagem']

        doc = nlp(mensagem)

        #entidades = [{'texto': ent.text, 'tipo': ent.label_} for ent in doc.ents]

        verbos = [token.text for token in doc if token.pos_ == 'VERB']
        loc =  [token.text for token in doc.ents if token.label_ == 'LOC']

        return jsonify({'verb': verbos, 'loc': loc})

    except Exception as e:
        return jsonify({'error': str(e)}), 500

if __name__ == '__main__':
    app.run(debug=True)
