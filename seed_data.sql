-- ============================================================
-- TsKids - Script de Seed Data
-- Marketplace de Carrinhos Elétricos Infantis
-- ============================================================
-- Execute este script no seu banco PostgreSQL (tskids_db)
-- Ele limpa os dados existentes e insere dados novos completos
-- ============================================================

BEGIN;

-- Limpa dados existentes (respeita FK)
TRUNCATE TABLE products, categories RESTART IDENTITY CASCADE;

-- ============================================================
-- CATEGORIAS
-- ============================================================

INSERT INTO categories (id, name, description, image_url) VALUES

('11111111-0000-0000-0000-000000000001',
 'Supercars',
 'Réplicas de Ferrari, Lamborghini, McLaren, Bugatti e outras supercars lendárias para os pequenos pilotos',
 'https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=600&q=80'),

('11111111-0000-0000-0000-000000000002',
 'SUVs e 4x4',
 'Réplicas de Land Rover, Range Rover, Mercedes GLE, Jeep e outros SUVs robustos para aventuras',
 'https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&q=80'),

('11111111-0000-0000-0000-000000000003',
 'Clássicos e Retrô',
 'Réplicas de Porsche 911, VW Fusca, Mini Cooper e outros ícones atemporais do automobilismo',
 'https://images.unsplash.com/photo-1566473965997-3de9c817e938?w=600&q=80'),

('11111111-0000-0000-0000-000000000004',
 'Motos Elétricas',
 'Réplicas de BMW, Honda, Harley-Davidson e outras motos icônicas para os pequenos motociclistas',
 'https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&q=80'),

('11111111-0000-0000-0000-000000000005',
 'Acessórios e Segurança',
 'Capacetes, coletes, luvas, pistas e acessórios para garantir segurança e diversão máxima',
 'https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=600&q=80'),

('11111111-0000-0000-0000-000000000006',
 'Caminhões e Tratores',
 'Réplicas de caminhões Scania, Mercedes, tratores e máquinas de construção em versão elétrica infantil',
 'https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=600&q=80'),

('11111111-0000-0000-0000-000000000007',
 'Carros de Corrida',
 'Réplicas de carros de Fórmula 1, NASCAR e categoria de corrida com visual agressivo e esportivo',
 'https://images.unsplash.com/photo-1594736797933-d0501ba2fe65?w=600&q=80');


-- ============================================================
-- PRODUTOS — SUPERCARS
-- ============================================================

INSERT INTO products (id, name, description, price, image_url, brand, stock, category_id, created_at, updated_at) VALUES

('22222222-0000-0000-0000-000000000001',
 'Ferrari SF90 Elétrico 12V',
 'Réplica oficial licenciada da Ferrari SF90 Stradale em versão infantil. Motor elétrico 12V com velocidade máxima de 5 km/h. Controle remoto parental 2.4GHz incluso, faróis e lanternas de LED, som do motor Ferrari gravado em estúdio, assento em couro ecológico e cinto de segurança de 3 pontos. Abertura de porta elétrica, painel funcional com velocímetro e luz de advertência. Indicado para crianças de 3 a 8 anos. Suporta até 35 kg.',
 3499.90,
 'https://images.unsplash.com/photo-1592198084033-aade902d1aae?w=600&q=80',
 'Ferrari Kids', 7,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000002',
 'Lamborghini Huracán 12V Amarela',
 'Réplica do Lamborghini Huracán com pintura exclusiva amarelo-pérola. Duas velocidades (3 e 5 km/h), abertura de portas no estilo tesoura elétrica, painel digital funcional, conexão Bluetooth para músicas e controle remoto 2.4GHz para os pais. Pneus de borracha com aro de liga leve. Suporta até 35 kg. Para crianças de 3 a 8 anos.',
 4199.00,
 'https://images.unsplash.com/photo-1544636331-e26879cd4d9b?w=600&q=80',
 'Lamborghini Junior', 4,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000003',
 'McLaren 720S Spider 12V',
 'Réplica do McLaren 720S com capota retrátil elétrica e tração nas 4 rodas. Motor 12V duplo, velocidade até 6 km/h, suspensão real com amortecedores, pneus de borracha e carregador incluso. Painel com controle de velocidade e modo pais. O presente da temporada para crianças de 4 a 9 anos.',
 4899.00,
 'https://images.unsplash.com/photo-1621135802920-133df287f89c?w=600&q=80',
 'McLaren Junior', 3,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000004',
 'Bugatti Chiron 24V - Edição Especial',
 'A réplica mais exclusiva do mercado! Bugatti Chiron em escala com acabamento premium. Bateria 24V de alta capacidade, velocidade de até 8 km/h, motor duplo tração 4x4, tela LCD no painel, som do motor W16 real, câmera traseira, banco duplo em couro legítimo e sistema de frenagem regenerativa. Apenas para colecionadores exigentes. Crianças de 4 a 10 anos. Até 50 kg.',
 7999.00,
 'https://images.unsplash.com/photo-1503376780353-7e6692767b70?w=600&q=80',
 'Bugatti Kids', 2,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000005',
 'Porsche Taycan Elétrico 12V',
 'Réplica do Porsche Taycan, o carro elétrico mais bonito do mundo, agora em versão infantil. Motor 12V silencioso, duas velocidades, som ambiente de aceleração elétrica, painel touchscreen decorativo, faróis full LED e rodas esportivas. Sustentável e estiloso desde pequeno. Para crianças de 3 a 8 anos.',
 3299.90,
 'https://images.unsplash.com/photo-1616455579100-2ceaa4eb1d2e?w=600&q=80',
 'Porsche Kids', 6,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000006',
 'Aston Martin DB11 12V',
 'Elegância britânica para os pequenos. Réplica do Aston Martin DB11 com acabamento premium em vermelho racing. Motor 12V, velocidade até 5 km/h, porta-malas funcional, sistema de som com MP3/USB/SD, faróis de LED e controle remoto parental incluído. Capacidade de até 30 kg.',
 2899.00,
 'https://images.unsplash.com/photo-1549399542-7e3f8b79c341?w=600&q=80',
 'Aston Martin Kids', 5,
 '11111111-0000-0000-0000-000000000001',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — SUVs E 4X4
-- ============================================================

('22222222-0000-0000-0000-000000000007',
 'Range Rover Evoque 12V Tração 4x4',
 'Réplica do Range Rover Evoque com tração 4x4 real. Motor duplo 12V, 3 marchas para frente e 1 ré, suspensão amortecida, tela MP3 com Bluetooth, faróis e lanternas de LED e controle remoto parental. Sistema de abertura de portas com controle. Suporta até 40 kg. Ideal para 3 a 10 anos.',
 2999.90,
 'https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&q=80',
 'Range Rover Kids', 9,
 '11111111-0000-0000-0000-000000000002',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000008',
 'Mercedes-Benz GLE AMG 24V - 2 Lugares',
 'O favorito das famílias! Réplica do Mercedes GLE AMG com dois assentos (leva dois pequenos pilotos). Bateria 24V, velocidade até 8 km/h, câmera de ré com monitor, tela touch colorida, som do motor V8 AMG, pneus com perfil off-road e controle remoto 2.4GHz. Suporta até 60 kg (30 kg por assento).',
 5499.00,
 'https://images.unsplash.com/photo-1561136594-7f68813b8a8b?w=600&q=80',
 'Mercedes Kids', 5,
 '11111111-0000-0000-0000-000000000002',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000009',
 'Jeep Wrangler Rubicon 12V Off-Road',
 'Aventura garantida com o Jeep Wrangler Rubicon infantil. Capota removível, pneus gigantes de borracha com tração 4x4, motor 12V duplo, diferencial de tração, faróis auxiliares LED, grade cromada e para-choques reforçado. Para os pequenos aventureiros de 3 a 9 anos. Suporta até 40 kg.',
 3199.00,
 'https://images.unsplash.com/photo-1601584115197-04ecc0da31d7?w=600&q=80',
 'Jeep Kids', 7,
 '11111111-0000-0000-0000-000000000002',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000010',
 'Land Rover Defender 110 12V',
 'Réplica fiel do Land Rover Defender 110, o rei do off-road. Carroceria reforçada, suspensão elevada, motor 12V com tração 4x4, estribo lateral, rack de teto com acessórios decorativos, faróis auxiliares e som ambiente de trilha. Para aventureiros de 3 a 9 anos.',
 3499.00,
 'https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600&q=80',
 'Land Rover Kids', 6,
 '11111111-0000-0000-0000-000000000002',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000011',
 'Toyota Hilux SW4 12V Pickup',
 'Réplica da Toyota Hilux SW4, a pickup mais confiável do Brasil em versão elétrica infantil. Caçamba funcional que desce e sobe, motor 12V duplo, tração 4x4, faróis de LED, grade cromada e controle remoto parental. Para crianças de 3 a 9 anos. Suporta até 35 kg.',
 2799.00,
 'https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=600&q=80',
 'Toyota Kids', 10,
 '11111111-0000-0000-0000-000000000002',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — CLÁSSICOS E RETRÔ
-- ============================================================

('22222222-0000-0000-0000-000000000012',
 'Porsche 911 Clássico 6V - Anos 70',
 'Réplica do icônico Porsche 911 anos 70 em versão elétrica infantil. Design clássico fiel ao original com pintura em prata metalizada. Motor 6V, velocidade suave de 3 km/h ideal para os menores, rodas de liga retrô, faróis redondos e buzina. Para crianças de 2 a 5 anos. Suporta até 25 kg.',
 1899.00,
 'https://images.unsplash.com/photo-1566473965997-3de9c817e938?w=600&q=80',
 'Porsche Heritage', 11,
 '11111111-0000-0000-0000-000000000003',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000013',
 'Mini Cooper S Elétrico Retrô',
 'Réplica do Mini Cooper S com visual retrô e personalizações exclusivas. Motor 12V, velocidade de 4 km/h, tejadilho com estampa Union Jack, rodas cromadas, banco de couro ecológico e faróis redondos. Uma das réplicas mais charmosas e instagramáveis do mercado! Para 3 a 8 anos.',
 2299.00,
 'https://images.unsplash.com/photo-1619767886558-efdc259b6e09?w=600&q=80',
 'Mini Kids', 8,
 '11111111-0000-0000-0000-000000000003',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000014',
 'Volkswagen Fusca 6V - Edição Flor',
 'O Fusca mais fofo do Brasil! Réplica do VW Fusca com pintura azul bebê e estampas de flores coloridas. Motor 6V, velocidade até 3 km/h, som da buzina "béé", faróis funcionais e rodas com calotas cromadas. Uma fofura que vira heirloom. Para crianças de 2 a 5 anos.',
 1599.00,
 'https://images.unsplash.com/photo-1533106418989-88406c7cc8ca?w=600&q=80',
 'VW Kids', 14,
 '11111111-0000-0000-0000-000000000003',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000015',
 'Chevrolet Corvette C3 Stingray 6V',
 'Réplica do lendário Corvette C3 Stingray dos anos 70. Design muscle car autêntico, pintura vermelho candy, motor 6V, velocidade até 3 km/h, capô com entradas de ar decorativas e rodas de liga wide. O carro dos sonhos em versão infantil. Para 2 a 6 anos.',
 1799.00,
 'https://images.unsplash.com/photo-1607853202273-797f1c22a38e?w=600&q=80',
 'Chevy Heritage Kids', 9,
 '11111111-0000-0000-0000-000000000003',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000016',
 'Ford Mustang Shelby GT500 12V',
 'Réplica do Mustang Shelby GT500, o muscle car mais famoso de todos os tempos. Motor 12V, velocidade até 5 km/h, pintura azul racing com listras brancas, faróis LED, buzina com som V8, banco em couro e rodas de liga esportivas. Para fãs de clássicos americanos de 3 a 8 anos.',
 2699.00,
 'https://images.unsplash.com/photo-1494976388531-d1058494cdd8?w=600&q=80',
 'Ford Kids', 7,
 '11111111-0000-0000-0000-000000000003',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — MOTOS ELÉTRICAS
-- ============================================================

('22222222-0000-0000-0000-000000000017',
 'BMW S1000RR Moto Infantil 6V',
 'Réplica da BMW S1000RR, a moto esportiva mais famosa do mundo em miniatura elétrica. Motor 6V, rodas de treinamento removíveis, faróis de LED, sons autênticos da BMW e velocidade até 4 km/h. Cúpula aerodinâmica decorativa e banco ajustável. Para crianças de 3 a 7 anos.',
 1299.00,
 'https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&q=80',
 'BMW Motorrad Kids', 14,
 '11111111-0000-0000-0000-000000000004',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000018',
 'Harley-Davidson Fat Boy 12V',
 'Réplica da lendária Harley-Davidson Fat Boy em versão infantil com estilo chopper autêntico. Motor 12V, banco duplo estofado, rodas largas cromadas, freios dianteiro e traseiro, som do motor Harley original e velocidade de 3 km/h. Para os pequenos com DNA de liberdade. De 3 a 8 anos.',
 1799.00,
 'https://images.unsplash.com/photo-1558981806-ec527fa84c39?w=600&q=80',
 'Harley-Davidson Kids', 6,
 '11111111-0000-0000-0000-000000000004',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000019',
 'Honda CB 1000R Neo Sports 6V',
 'Réplica da Honda CB 1000R com design Neo Sports Café. Motor 6V, freio a disco decorativo, faróis LED redondos, guidão esportivo e painel digital decorativo. Nas cores preta ou branca. Rodas de treinamento removíveis. Para crianças de 3 a 7 anos. Suporta até 30 kg.',
 1199.00,
 'https://images.unsplash.com/photo-1609630875171-b1321377ee65?w=600&q=80',
 'Honda Kids', 17,
 '11111111-0000-0000-0000-000000000004',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000020',
 'Kawasaki Ninja ZX-10R 12V',
 'A moto mais rápida do mundo em versão para crianças! Réplica da Kawasaki Ninja ZX-10R na icônica cor verde Kawasaki. Motor 12V, duas velocidades, faróis duplos de LED, escapamento decorativo cromado, som do motor inline-4 e rodas de treinamento. Para 3 a 8 anos.',
 1499.00,
 'https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?w=600&q=80',
 'Kawasaki Kids', 10,
 '11111111-0000-0000-0000-000000000004',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000021',
 'Ducati Panigale V4 12V - Vermelha',
 'A moto italiana mais desejada em versão infantil. Réplica da Ducati Panigale V4 na tradicional vermelho Ducati. Motor 12V, carenagem aerodinâmica completa, freios a disco decorativos, escapamentos laterais cromados e painel digital. Para crianças de 3 a 8 anos. Suporta até 30 kg.',
 1699.00,
 'https://images.unsplash.com/photo-1558618666-fcd25c85cd64?w=600&q=80',
 'Ducati Kids', 8,
 '11111111-0000-0000-0000-000000000004',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — ACESSÓRIOS E SEGURANÇA
-- ============================================================

('22222222-0000-0000-0000-000000000022',
 'Capacete Infantil Piloto Pro - 5 Cores',
 'Capacete homologado especialmente para uso em carrinhos elétricos infantis. Estrutura em ABS resistente a impactos, viseira anti-risco e anti-UV, interior acolchoado em espuma EPS lavável, fecho de engate rápido e regulagem de tamanho por dial. Disponível em vermelho, amarelo, azul, branco e preto. Tamanhos P (48-50cm), M (51-54cm) e G (55-58cm).',
 189.90,
 'https://images.unsplash.com/photo-1551698618-1dfe5d97d256?w=600&q=80',
 'TsKids Gear', 40,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000023',
 'Colete de Segurança Infantil TsKids',
 'Colete de segurança desenvolvido especificamente para pilotos mirins. Espuma de alta densidade nas costas, peito e ombros. Fechamento por velcro ajustável, tecido respirável, tiras refletivas 360° e design Racing Team. Tamanhos P (2-4 anos), M (5-7 anos) e G (8-10 anos). Lavável na máquina.',
 149.90,
 'https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?w=600&q=80',
 'TsKids Gear', 35,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000024',
 'Luvas de Piloto Infantil Premium',
 'Luvas de couro ecológico com proteção no dorso da mão e palma antiderrapante. Design Racing com tiras ajustáveis no pulso, ventilação nas laterais e bordado TsKids. Tamanhos PP, P, M e G. Disponíveis em preto/vermelho, preto/azul e branco/laranja.',
 69.90,
 'https://images.unsplash.com/photo-1598300042247-d088f8ab3a91?w=600&q=80',
 'TsKids Gear', 60,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000025',
 'Pista de Corrida Dobrável 8m',
 'Monte um circuito de verdade no quintal ou na sala! Pista dobrável de 8 metros com marcações de pista, zebrado, boxes e área de pit stop. Material em lona vinílica resistente à água, antiderrapante na base e fácil de montar/guardar. Inclui 4 cones de sinalização e 1 bandeira quadriculada. Para carrinhos de até 40 kg.',
 399.90,
 'https://images.unsplash.com/photo-1568772585407-9361f9bf3a87?w=600&q=80',
 'TsKids Racing', 15,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000026',
 'Carregador Universal 12V/24V Smart',
 'Carregador inteligente compatível com todos os carrinhos elétricos 12V e 24V do mercado. Proteção contra sobrecarga, curto-circuito e superaquecimento. Indicador LED de carga (vermelho carregando / verde completo). Cabo de 1,5m e plug universal. Garante maior vida útil para a bateria.',
 89.90,
 'https://images.unsplash.com/photo-1609091839311-d5365f9ff1c5?w=600&q=80',
 'TsKids Tech', 55,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000027',
 'Controle Remoto Parental 2.4GHz',
 'Controle remoto universal para carrinhos elétricos infantis. Tecnologia 2.4GHz com alcance de até 30 metros e sem interferência. Funções: andar para frente/ré, virar esquerda/direita, buzina e freio de emergência. Bateria AA incluída. Compatível com a maioria dos carrinhos 12V e 24V do mercado.',
 129.90,
 'https://images.unsplash.com/photo-1593508512255-86ab42a8e620?w=600&q=80',
 'TsKids Tech', 45,
 '11111111-0000-0000-0000-000000000005',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — CAMINHÕES E TRATORES
-- ============================================================

('22222222-0000-0000-0000-000000000028',
 'Scania R730 Caminhão Elétrico 12V',
 'Réplica do Scania R730 em versão infantil com cabine de dormir. Motor 12V, cabine funcional que abre, caçamba articulada que sobe e desce, faróis de trabalho LED, buzina de ar e sons de caminhão autênticos. Inclui carreta decorativa. Para os futuros caminhoneiros de 3 a 8 anos.',
 2499.00,
 'https://images.unsplash.com/photo-1558618047-3c8c76ca7d13?w=600&q=80',
 'Scania Kids', 5,
 '11111111-0000-0000-0000-000000000006',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000029',
 'Trator John Deere Elétrico 6V',
 'Réplica do famoso trator John Deere na icônica cor verde e amarela. Motor 6V, rodas grandes com pneus de borracha, direção funcional, buzina, caçamba traseira que bascula e reboque incluso. Para os pequenos fazendeiros de 2 a 5 anos. O presente favorito nas cidades do interior!',
 1399.00,
 'https://images.unsplash.com/photo-1592805723127-004b174a1798?w=600&q=80',
 'John Deere Kids', 12,
 '11111111-0000-0000-0000-000000000006',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000030',
 'Escavadeira CAT 6V com Caçamba',
 'Réplica da escavadeira Caterpillar com braço articulado e caçamba funcional. Motor 6V, braço hidráulico (elétrico) que sobe, desce e gira 180°, caçamba que abre e fecha, som de obra e faróis de trabalho. Para os pequenos engenheiros de 2 a 6 anos. Suporta até 30 kg.',
 1599.00,
 'https://images.unsplash.com/photo-1589939705384-5185137a7f0f?w=600&q=80',
 'CAT Kids', 8,
 '11111111-0000-0000-0000-000000000006',
 NOW(), NOW()),


-- ============================================================
-- PRODUTOS — CARROS DE CORRIDA
-- ============================================================

('22222222-0000-0000-0000-000000000031',
 'Fórmula 1 Red Bull Racing 12V',
 'Réplica do monoposto de F1 da Red Bull Racing com visual idêntico ao carro oficial da equipe. Motor 12V, aerofólio dianteiro e traseiro ajustáveis, cockpit fechado com viseira, rodas de F1, halo de segurança e número do piloto personalizável. Para futuros campeões de 4 a 9 anos.',
 3199.00,
 'https://images.unsplash.com/photo-1594736797933-d0501ba2fe65?w=600&q=80',
 'Red Bull Racing Kids', 4,
 '11111111-0000-0000-0000-000000000007',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000032',
 'Kart Elétrico Racing 24V - Pro',
 'O mais próximo de um kart real em versão infantil! Motor 24V de alta performance, chassis em aço tubular, assento ergonômico ajustável, volante esportivo, pedal de aceleração e freio independentes, pneus de borracha de baixo perfil e velocidade até 12 km/h (ajustável em 3 níveis). Para crianças de 6 a 14 anos. Suporta até 60 kg.',
 4599.00,
 'https://images.unsplash.com/photo-1540747913346-19e32dc3e97e?w=600&q=80',
 'TsKids Racing Pro', 3,
 '11111111-0000-0000-0000-000000000007',
 NOW(), NOW()),

('22222222-0000-0000-0000-000000000033',
 'Ferrari F2004 Fórmula 1 12V - Schumacher',
 'Homenagem ao maior campeão da F1! Réplica da Ferrari F2004 de Michael Schumacher, o carro mais vitorioso da história. Pintura vermelho Scuderia com número 1, motor 12V, aerofólio de F1, rodas de aro baixo e cockpit com balaclava decorativa inclusa. Edição limitada para colecionadores. Para 4 a 9 anos.',
 3599.00,
 'https://images.unsplash.com/photo-1592198084033-aade902d1aae?w=600&q=80',
 'Ferrari Kids Heritage', 3,
 '11111111-0000-0000-0000-000000000007',
 NOW(), NOW());


COMMIT;

-- ============================================================
-- VERIFICAÇÃO FINAL
-- ============================================================
SELECT
    c.name AS categoria,
    COUNT(p.id) AS total_produtos,
    MIN(p.price) AS menor_preco,
    MAX(p.price) AS maior_preco
FROM categories c
LEFT JOIN products p ON p.category_id = c.id
GROUP BY c.name
ORDER BY c.name;
